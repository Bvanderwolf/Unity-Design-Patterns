using System;
using BWolf.Patterns.Singleton.Exceptions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace BWolf.Patterns.Singleton
{
    /// <summary>
    /// Holds information related to the creation of singletons in the application.
    /// </summary>
    public static class SingletonBootstrapInfo
    {
        /// <summary>
        /// The first scene that was loaded by the application.
        /// </summary>
        public static Scene FirstSceneLoaded { get; private set; }
        
        /// <summary>
        /// The settings used to instantiate singletons in the application.
        /// </summary>
        public static SingletonSettings Settings { get; private set; }
        
        private static Transform _singletonParentTransform;
        
        private static bool _booting;
        
        static SingletonBootstrapInfo()
        {
            Settings = null;
            _singletonParentTransform = null;
            _booting = false;

            RefreshSceneManagementListeners();
        }
        
        /// <summary>
        /// Returns whether a singleton profile is available in the project and it has singletons in it.
        /// </summary>
        /// <returns>Whether a singleton profile is available in the project and it has singletons in it.</returns>
        public static bool HasProfileWithSingletons() => Settings != null && Settings.profile != null && Settings.profile.Size != 0;
        
        /// <summary>
        /// Returns whether a singletons instantiation has been set by the profile. This value
        /// is updated just before singleton creation is used to stop recursion
        /// from happening when a component on the singleton prefab calls the singleton component
        /// before it has assigned its instance value.
        /// </summary>
        /// <typeparam name="T">The type of singleton behaviour to check.</typeparam>
        /// <returns>Whether the singletons instantiation has been set by the profile.</returns>
        internal static bool CheckSingletonInstantiation<T>() where T : MonoBehaviour
        {
            return Settings.profile.TryGetInfo(typeof(T), out BootInfo info) && info.IsInstantiated;
        }
        
        /// <summary>
        /// Instantiates a singleton type outside of bootstrap. This is only used for ensuring singletons created
        /// before the first scene is loaded can use other singleton instances in their initialization.
        /// </summary>
        /// <typeparam name="T">The type of singleton to instantiate.</typeparam>
        /// <returns>The created singleton component instance.</returns>
        internal static T InstantiateSingletonBehaviour<T>() where T : MonoBehaviour
        {
            if (!HasProfileWithSingletons())
                throw new InvalidOperationException(ExceptionMessages.GetFor<T>(ExceptionMessage.INVALID_PROFILE));
            
            if (!Settings.profile.TryGetInfo(typeof(T), out BootInfo info))
                throw new InvalidOperationException(ExceptionMessages.GetFor<T>(ExceptionMessage.MISSING_BOOT_INFO));

            if (info.Mode == BootMode.DISABLED)
                throw new InvalidOperationException($"The {typeof(T).Name} singleton its instantiation call was made while it has been set to disabled. Make sure to set the mode correctly.");
            
            if (info.IsInstantiated)
                throw new InvalidOperationException($"The {typeof(T).Name} singleton its instantiation call was made while it already existed. Something went wrong during the creation of the singleton prefab.");

            if (!_booting && !info.HasVariableTimeOfCreation)
                throw new InvalidOperationException($"The {typeof(T).Name} singleton is part of the profile but has not been bootstrapped before the first scene while it should. Something went wrong during the bootstrap operation.");

            if (info.Mode == BootMode.SCENE)
                return InstantiateSceneSingletonBehaviour<T>(info);
 
            return InstantiateSingletonBehaviour<T>(info); 
        }
        
        /// <summary>
        /// Refreshes the listening for scene management updates.
        /// </summary>
        private static void RefreshSceneManagementListeners()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.sceneUnloaded -= OnSceneUnloaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }
        
        /// <summary>
        /// Creates singletons that have the loaded scene as their bootstrap scene.
        /// </summary>
        /// <param name="scene">The loaded scene.</param>
        /// <param name="loadSceneMode">The load scene mode in which the scene was loaded.</param>
        private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (!HasProfileWithSingletons())
                return;

            foreach (BootInfo info in Settings.profile)
                if (!info.IsInstantiated && info.SceneName == scene.name)
                    InstantiateSingleton(info);
        }

        /// <summary>
        /// Destroys singletons that had the unloaded scene as their bootstrap scene.
        /// </summary>
        /// <param name="scene">The unloaded scene.</param>
        private static void OnSceneUnloaded(Scene scene)
        {
            if (!HasProfileWithSingletons())
                return;

            foreach (BootInfo info in Settings.profile)
            {
                if (info.IsInstantiated && info.SceneName == scene.name)
                {
                    Object.Destroy(info.Instance);
                    info.Reset();
                }
            }
        }
        
        /// <summary>
        /// Instantiates the singletons stored in the singleton profile before scene load using
        /// the 'RuntimeInitializeOnLoadMethod' attribute.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InstantiateSingletonsUsingProfile()
        {
            _booting = true;
            
            FirstSceneLoaded = SceneManager.GetActiveScene();
            Settings = Resources.Load<SingletonSettings>(nameof(SingletonSettings));
            
            if (!HasProfileWithSingletons())
                return;

            GameObject rootGameObject = new GameObject("~SingletonBehaviours");
            Object.DontDestroyOnLoad(rootGameObject);

            _singletonParentTransform = rootGameObject.transform;
            
            for (int i = 0; i < Settings.profile.Size; i++)
            {
                BootInfo info = Settings.profile.GetInfoAt(i);
                if (info.Prefab == null)
                {
                    Debug.LogWarning(ExceptionMessages.Get(ExceptionMessage.MISSING_PREFAB, i, Settings.profile.name));
                    continue;
                }

                if (info.IsCreatedAtBoot) 
                    InstantiateSingleton(info);
            }

            _booting = false;
        }
        
        /// <summary>
        /// Instantiates a singleton using the given boot info.
        /// </summary>
        /// <param name="info">The info to use for creating the singleton.</param>
        private static void InstantiateSingleton(BootInfo info)
        {
            GameObject gameObject = Object.Instantiate(info.Prefab, _singletonParentTransform);
            gameObject.name = info.Prefab.name;

            info.Instance = gameObject;
            info.IsInstantiated = true;
        }

        /// <summary>
        /// Instantiates a singleton to be used in its specified scene.
        /// </summary>
        /// <typeparam name="T">The type of singleton to create.</typeparam>
        /// <param name="info">The info to use for creating the singleton.</param>
        /// <returns>The singleton component instance.</returns>
        private static T InstantiateSceneSingletonBehaviour<T>(BootInfo info) where T : MonoBehaviour
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
                if (SceneManager.GetSceneAt(i).name == info.SceneName)
                    return InstantiateSingletonBehaviour<T>(info);

            throw new InvalidOperationException(ExceptionMessages.GetFor<T>(ExceptionMessage.INVALID_SCENE_SINGLETON));
        }

        /// <summary>
        /// Instantiates a singleton using the given boot info. This should only be used for
        /// ensuring singletons created before scene load can use other singleton instances in
        /// their initialization.
        /// </summary>
        /// <typeparam name="T">The type of singleton to create.</typeparam>
        /// <param name="info">The info to use for creating the singleton.</param>
        /// <returns>The singleton component instance.</returns>
        private static T InstantiateSingletonBehaviour<T>(BootInfo info) where T : MonoBehaviour
        {
            // Set instantiation flag before instantiation to avoid recursion in the 
            // case of a component on the same prefab calling the singleton
            // before it is created.
            info.IsInstantiated = true;
            
            GameObject gameObject = Object.Instantiate(info.Prefab, _singletonParentTransform);
            gameObject.name = info.Prefab.name;

            info.Instance = gameObject;

            return (gameObject.GetComponentInChildren<T>());
        }
    }
}
