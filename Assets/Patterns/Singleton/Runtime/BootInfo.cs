using System;
using UnityEngine;

namespace BWolf.Patterns.Singleton
{
    /// <summary>
    /// Holds all information relation to the creation of the singleton.
    /// </summary>
    [Serializable]
    public class BootInfo
    {
        [SerializeField]
        [Tooltip("The prefab containing the singleton component.")]
        private GameObject _prefab = null;
        
        [SerializeField]
        [Tooltip("The way the singleton will be created during the applications lifetime.")]
        private BootMode _mode = BootMode.DISABLED;
        
        [SerializeField]
        [Tooltip("The name of the scene in which the singleton will exist if its boot mode is set to 'scene'.")]
        private string _sceneName = string.Empty;
        
        /// <summary>
        /// The prefab containing the singleton component.
        /// </summary>
        public GameObject Prefab => _prefab;

        /// <summary>
        /// The way the singleton will be created during the applications lifetime.
        /// </summary>
        public BootMode Mode => _mode;

        /// <summary>
        /// The name of the scene in which the singleton exists if its boot mode is set to 'scene'.
        /// </summary>
        public string SceneName => _sceneName;

        /// <summary>
        /// The game object instance created from instantiating the prefab.
        /// </summary>
        public GameObject Instance
        {
            get => _instance;
            internal set => _instance = value;
        }
        
        /// <summary>
        /// Whether the singleton instance is instantiated.
        /// </summary>
        public bool IsInstantiated
        {
            get => _isInstantiated;
            internal set => _isInstantiated = value;
        }
        /// <summary>
        /// Whether the singleton is created before the first scene is loaded. This is true for singletons with
        /// a default boot mode.
        /// </summary>
        public bool IsCreatedAtBoot => !_isInstantiated && _mode == BootMode.DEFAULT;

        /// <summary>
        /// Whether the singleton will be created at variable time during the application
        /// its lifecycle. This could be because it has its boot mod set to lazy or scene.
        /// </summary>
        public bool HasVariableTimeOfCreation => _mode == BootMode.LAZY || _mode == BootMode.SCENE;
        
        [NonSerialized]
        private bool _isInstantiated;
        
        [NonSerialized]
        private GameObject _instance;
        
        /// <summary>
        /// Resets the boot info state.
        /// </summary>
        internal void Reset()
        {
            _isInstantiated = false;
            _instance = null;
        }
    }
}
