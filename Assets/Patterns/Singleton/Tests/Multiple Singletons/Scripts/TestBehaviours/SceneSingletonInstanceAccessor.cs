using System;
using System.Collections;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
    public class SceneSingletonInstanceAccessor : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return null;
        
            AssertExistence("Start");
            AssertAccessibleInstance("Start");
            
            SceneSingleton.Instance.OnBeforeDestroy += AssertAccessibleInstance;
        }

        private static void AssertExistence(string method)
        {
            Assert.IsTrue(SceneSingleton.Exists, $"[SceneSingletonInstanceAccessor.{method}]");
        }
        
        private static void AssertAccessibleInstance(SceneSingleton instance)
        {
            Assert.IsNotNull(instance, "[OnBeforeDestroy += SceneSingletonInstanceAccessor.AssertAccessibleInstance]");
        }

        private static void AssertAccessibleInstance(string method)
        {
            Assert.IsNotNull(SceneSingleton.Instance, $"[SceneSingletonInstanceAccessor.{method}]");
        }
    }   
}
