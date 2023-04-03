using UnityEngine;

namespace BWolf.Patterns.Singleton
{
    /// <summary>
    /// Holds data related to the management of singletons in the project.
    /// </summary>
    [CreateAssetMenu(fileName = nameof(SingletonSettings), menuName = "Patterns/Singleton/Settings")]
    public class SingletonSettings : ScriptableObject
    {
        /// <summary>
        /// Whether there should be a check on the correct usage of the singleton profile
        /// during the build process. Setting this to true might stop the build if it the
        /// profile isn't used correctly.
        /// </summary>
        [Header("Settings")]
        [Tooltip(
            "Whether there should be a check on the correct usage of the singleton profile during the build process.")]
        public bool runPreBuildCheck = true;

        /// <summary>
        /// The profile used to instantiate singletons in the application.
        /// </summary>
        public SingletonProfile profile;
    }
}
