using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
    public class DefaultSingletonInstanceAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertExistence("Awake");
            AssertAccessibleInstance("Awake");
            
            DefaultSingleton.Instance.OnBeforeDestroy += AssertAccessibleInstance;
        }

        private void Start()
        {
            AssertExistence("Start");
            AssertAccessibleInstance("Start");
        }

        private void OnEnable()
        {
            AssertExistence("OnEnable");
            AssertAccessibleInstance("OnEnable");
        }

        private static void AssertExistence(string method)
        {
            Assert.IsTrue(DefaultSingleton.Exists, $"[DefaultSingletonInstanceAccessor.{method}]");
        }
        
        private static void AssertAccessibleInstance(DefaultSingleton instance)
        {
            Assert.IsNotNull(instance, "[OnBeforeDestroy += DefaultSingletonInstanceAccessor.AssertAccessibleInstance]");
        }

        private static void AssertAccessibleInstance(string method)
        {
            Assert.IsNotNull(DefaultSingleton.Instance, $"[DefaultSingletonInstanceAccessor.{method}]");
        }
    }
}
