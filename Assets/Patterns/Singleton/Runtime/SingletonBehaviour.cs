using System;
using BWolf.Patterns.Singleton.Exceptions;
using UnityEngine;

namespace BWolf.Patterns.Singleton
{
    /// <summary>
    /// Represents the core singleton behaviour compatible with unity's object lifecycle.
    /// An implementation should be part of a prefab asset so it can be added to a singleton profile.
    /// </summary>
    /// <typeparam name="T">The type of mono behavior becoming a singleton instance.</typeparam>
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Whether the singleton instance is accessible.
        /// </summary>
        public static bool Exists => _instance != null && !_isBeingDestroyedByApp;
        
        /// <summary>
        /// Called during the destruction of the singleton.
        /// </summary>
        public event Action<T> OnBeforeDestroy;
        
        /// <summary>
        /// The instance of the singleton in the application.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (!Application.isPlaying)
                    throw new InvalidOperationException($"{typeof(T).Name} its instance is accessed during editor mode. Make sure to call it only during runtime.");

                if (_isBeingDestroyedByApp)
                    throw new InvalidOperationException(ExceptionMessages.GetFor<T>(ExceptionMessage.IS_BEING_DESTROYED_BY_APP));

                if (_instance == null)
                {
                    if (SingletonBootstrapInfo.CheckSingletonInstantiation<T>())
                    {
                        // If the existence of the singleton has been set by the
                        // bootstrap service but the instance is null, a component
                        // on the singleton prefab is calling the instance before the
                        // singleton itself can set it. To avoid recursion from happening
                        // the instance is set using an expensive FindObjectOfType call.
                        Debug.LogWarning($"{typeof(T).Name} its instance is accessed by a sibling component during initialization. To avoid recursion the instance is set using an expensive FindObjectOfType call. It is advised to use GetComponent<{typeof(T).Name}> instead.");
                        _instance = FindObjectOfType<T>();
                    }
                    else
                    {
                        // If the existence of the singleton has not yet been set by the bootstrap
                        // service, its assumed its boot mode is set to lazy. We can return an instantiation
                        // using the singleton profile.
                        _instance = SingletonBootstrapInfo.InstantiateSingletonBehaviour<T>();
                    }
                }

                return _instance;
            }
        }

        private static T _instance;

        private static bool _isBeingDestroyedByApp;

        protected virtual void Awake()
        {
            _isBeingDestroyedByApp = false;
            
            if (Exists && _instance != this)
            {
                Debug.LogWarning($"Destroying a new instance of {typeof(T).Name} that has been encountered. :: make sure the component is not part of a scene.");
                Destroy(gameObject);
            }
            else
            {
                _instance = this as T;
            }
        }
        
        protected virtual void OnDestroy()
        {
            OnBeforeDestroy?.Invoke(this as T);

            if (Exists && _instance == this)
                _instance = null;
        }
        
        private void OnApplicationQuit() => _isBeingDestroyedByApp = true;
    }
}
