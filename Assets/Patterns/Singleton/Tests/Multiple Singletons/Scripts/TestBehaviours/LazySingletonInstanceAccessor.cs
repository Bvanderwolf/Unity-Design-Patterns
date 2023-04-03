using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
    public class LazySingletonInstanceAccessor : MonoBehaviour
    {
        private static bool firstAwakeInApp = false;
        
        private void Awake()
        {
            if (!firstAwakeInApp)
            {
                AssertNonExistence("Awake");
                firstAwakeInApp = true;
            }
            AssertAccessibleInstance("Awake");
            AssertExistence("Awake");
            
            LazySingleton.Instance.OnBeforeDestroy += AssertAccessibleInstance;
        }
        
        private void Start()
        {
            AssertAccessibleInstance("Start");
            AssertExistence("Start");
        }
        
        private void OnEnable()
        {
            AssertAccessibleInstance("OnEnable");
            AssertExistence("OnEnable");
        }
        
        private static void AssertNonExistence(string method)
        {
            Assert.IsFalse(SceneSingleton.Exists, $"[LazySingletonInstanceAccessor.{method}]");
        }
        
        private static void AssertExistence(string method)
        {
            Assert.IsTrue(LazySingleton.Exists, $"[LazySingletonInstanceAccessor.{method}]");
        }
        
        private static void AssertAccessibleInstance(LazySingleton instance)
        {
            Assert.IsNotNull(instance, "[OnBeforeDestroy += LazySingletonInstanceAccessor.AssertAccessibleInstance]");
        }
        
        private static void AssertAccessibleInstance(string method)
        {
            Assert.IsNotNull(LazySingleton.Instance, $"[LazySingletonInstanceAccessor.{method}]");
        }
    }
}
