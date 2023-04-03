using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.SingletonInteraction
{
    public class FirstDefaultSingleton : SingletonBehaviour<FirstDefaultSingleton>
    {
        protected override void Awake()
        {
            base.Awake();
            AssertAccessibleInstance(SecondDefaultSingleton.Instance, "Awake");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "Awake");
            AssertAccessibleInstance(InitialSceneSingleton.Instance, "Awake");
        }

        private void OnEnable()
        {
            AssertAccessibleInstance(SecondDefaultSingleton.Instance, "OnEnable");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "OnEnable");
            AssertAccessibleInstance(InitialSceneSingleton.Instance, "OnEnable");
        }

        private void Start()
        {
            AssertAccessibleInstance(SecondDefaultSingleton.Instance, "Start");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "Start");
            AssertAccessibleInstance(InitialSceneSingleton.Instance, "Start");
        }
        
        public void Use()
        {
            
        }

        private static void AssertAccessibleInstance<T>(SingletonBehaviour<T> instance, string method) where T : MonoBehaviour
        {
            Assert.IsNotNull(instance, $"[FirstDefaultSingleton.{method}]");
        }
    }
}
