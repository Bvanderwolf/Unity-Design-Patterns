﻿using UnityEngine;

namespace BWolf.Patterns.Singleton
{
    /// <summary>
    /// Defines the ways a singleton can be created during the applications lifetime.
    /// </summary>
    public enum BootMode
    {
        /// <summary>
        /// The singleton won't get created.
        /// </summary>
        [InspectorName("Disabled")]
        [Tooltip("The singleton won't get created.")]
        DISABLED = 0,

        /// <summary>
        /// The singleton will be created before the first scene of the application is loaded.
        /// </summary>
        [InspectorName("Default")]
        [Tooltip("The singleton will be created before the first scene of the application is loaded.")]
        DEFAULT = 1,

        /// <summary>
        /// The singleton will be created when its instance is first used.
        /// </summary>
        [InspectorName("Lazy")]
        [Tooltip("The singleton will be created when its instance is first used.")]
        LAZY = 2,

        /// <summary>
        /// The singleton will be created when a specific scene is loaded and destroyed when this scene is unloaded.
        /// Note that using this boot mode causes it to be created after the scene has loaded causing its instance
        /// to be available after Start is called on scene objects. You can yield return null in Start to wait for
        /// this to happen.
        /// </summary>
        [InspectorName("Scene")]
        [Tooltip("The singleton will be created when a specific scene is loaded and destroyed when this scene is unloaded.")]
        SCENE = 3,
    }
}
