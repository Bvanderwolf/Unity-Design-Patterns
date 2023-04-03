using System;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.OneSingleton
{
    public class SingletonInstanceAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertExistence("Awake");
            AssertAccessibleInstance("Awake");
            AssertHasProfileWithSingletons("Awake");
            
            Singleton.Instance.OnBeforeDestroy += AssertAccessibleInstance;
        }

        private void Start()
        {
            AssertExistence("Start");
            AssertAccessibleInstance("Start");
            AssertHasProfileWithSingletons("Start");
        }

        private void OnEnable()
        {
            AssertExistence("OnEnable");
            AssertAccessibleInstance("OnEnable");
            AssertHasProfileWithSingletons("OnEnable");
        }

        private void OnDestroy()
        {
            AssertNonExistence("OnDestroy");
            
            try
            {
                Singleton.Instance.Use();
                Assert.Fail($"[SingletonInstanceAccessor.OnDestroy]");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, ExceptionMessages.GetFor<Singleton>(ExceptionMessage.IS_BEING_DESTROYED_BY_APP));
            }
        }

        private static void AssertHasProfileWithSingletons(string method)
        {
            Assert.IsTrue(SingletonBootstrapInfo.HasProfileWithSingletons(), $"[SingletonInstanceAccessor.{method}]");
        }

        private static void AssertNonExistence(string method)
        {
            Assert.IsFalse(Singleton.Exists, $"[SingletonInstanceAccessor.{method}]");
        }

        private static void AssertExistence(string method)
        {
            Assert.IsTrue(Singleton.Exists, $"[SingletonInstanceAccessor.{method}]");
        }
        
        private static void AssertAccessibleInstance(Singleton instance)
        {
            Assert.IsNotNull(instance, "[OnBeforeDestroy += SingletonInstanceAccessor.AssertAccessibleInstance]");
        }

        private static void AssertAccessibleInstance(string method)
        {
            Assert.IsNotNull(Singleton.Instance, $"[SingletonInstanceAccessor.{method}]");
        }
    }
}
