using System;
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
                    throw new InvalidOperationException($"{typeof(T).Name} its instance was accessed while it was being destroyed by the application quit event. This is probably  because of an OnDestroy call to it during application quit. There is no guarantee that it will  be alive during this time. Use the 'Exists' property or the 'OnBeforeDestroy' event instead.");

                if (_instance == null)
                {
                    if (SingletonBootstrapInfo.CheckSingletonInstantiation<T>())
                    {
                        // If the existence of the singleton has been set by the
                        // bootstrap service but the instance is null, a component
                        // on the singleton prefab is calling the instance before the
                        // singleton itself can set it. To avoid recursion from happening
                        // the instance is set using an expensive FindObjectOfType call.
                        _instance = FindObjectOfType<T>();
                    }
                    else
                    {
                        // If the existence of the singleton has not yet been set by the bootstrap
                        // service, its assumed its boot mode is set to lazy can return an instantiation
                        // using the singleton profile.
                        _instance = SingletonBootstrapInfo.InstantiateSingletonInternal<T>();
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
                Debug.LogWarning($"A new instance of {typeof(T).Name} has been encountered, destroying it. :: make sure the component is not part of a scene.");
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
