using System.Collections;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
    public class FirstSceneSingletonInstanceAccessor : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return null;
            
            AssertExistence("Start");
            AssertAccessibleInstance("Start");
            
            FirstSceneSingleton.Instance.OnBeforeDestroy += AssertAccessibleInstance;
        }

        private static void AssertExistence(string method)
        {
            Assert.IsTrue(FirstSceneSingleton.Exists, $"[FirstSceneSingletonInstanceAccessor.{method}]");
        }
        
        private static void AssertAccessibleInstance(FirstSceneSingleton instance)
        {
            Assert.IsNotNull(instance, "[OnBeforeDestroy += FirstSceneSingletonInstanceAccessor.AssertAccessibleInstance]");
        }

        private static void AssertAccessibleInstance(string method)
        {
            Assert.IsNotNull(FirstSceneSingleton.Instance, $"[FirstSceneSingletonInstanceAccessor.{method}]");
        }
    }
}
