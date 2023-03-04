using System;
using System.Collections;
using UnityEngine;

namespace BWolf.Patterns.Singleton
{
    /// <summary>
    /// The container of references to singleton prefabs that are going
    /// to be created when the application is started.
    /// </summary>
    [CreateAssetMenu(fileName = nameof(SingletonProfile), menuName = "Patterns/Singleton/Profile")]
    public class SingletonProfile : ScriptableObject, IEnumerable
    {
        [Header("Boot info")]
        [SerializeField]
        private BootInfo[] _info;

        public int Size => _info.Length;

        public BootInfo GetInfoAt(int index)
        {
            try
            {
                return (_info[index]);
            }
            catch (ArgumentOutOfRangeException)
            {
                return (null);
            }
        }

        /// <summary>
        /// Returns the boostrap info of a singleton in the profile.
        /// </summary>
        /// <param name="singletonType">The type of the singleton.</param>
        /// <param name="info"></param>
        /// <returns>The singleton bootstrap info.</returns>
        public bool TryGetInfo(Type singletonType, out BootInfo info)
        {
            info = default;
            
            foreach (BootInfo bootInfo in _info)
            {
                if (bootInfo.Prefab.GetComponentInChildren(singletonType) != null)
                {
                    info = bootInfo;
                    return (true);
                }
            }

            return false;
        }

        public IEnumerator GetEnumerator() => _info.GetEnumerator();
    }
}
