using System;
using System.Collections;
using UnityEngine;
using BWolf.Patterns.Singleton.Exceptions;

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
        private BootInfo[] _info = null;

        /// <summary>
        /// The amount of singletons currently in the profile.
        /// </summary>
        public int Size => _info.Length;

        /// <summary>
        /// Returns boot information of a singleton at a given index in the array.
        /// Returns null if the index is out of bounds.
        /// </summary>
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
            
            for (int i = 0; i < _info.Length; i++)
            {
                BootInfo bootInfo = _info[i];
                if (bootInfo.Prefab == null)
                    throw new InvalidOperationException(ExceptionMessages.Get(ExceptionMessage.MISSING_PREFAB, i, name));

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
