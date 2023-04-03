using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.SingletonInteraction
{
    public class InitialSceneSingleton : SingletonBehaviour<InitialSceneSingleton>
    {
        protected override void Awake()
        {
            base.Awake();
            AssertAccessibleInstance(FirstDefaultSingleton.Instance, "Awake");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "Awake");
            AssertAccessibleInstance(SecondDefaultSingleton.Instance, "Awake");
            AssertAccessibleInstance(SecondInitialSceneSingleton.Instance, "Awake");
        }
        
        private void OnEnable()
        {
            AssertAccessibleInstance(FirstDefaultSingleton.Instance, "OnEnable");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "OnEnable");
            AssertAccessibleInstance(SecondDefaultSingleton.Instance, "OnEnable");
            AssertAccessibleInstance(SecondInitialSceneSingleton.Instance, "OnEnable");
        }
        
        private void Start()
        {
            AssertAccessibleInstance(FirstDefaultSingleton.Instance, "Start");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "Start");
            AssertAccessibleInstance(SecondDefaultSingleton.Instance, "Start");
            AssertAccessibleInstance(SecondInitialSceneSingleton.Instance, "Start");
        }

        public void Use()
        {
            
        }
        
        private static void AssertAccessibleInstance<T>(SingletonBehaviour<T> instance, string method) where T : MonoBehaviour
        {
            Assert.IsNotNull(instance, $"[InitialSceneSingleton.{method}]");
        }
    }
}
