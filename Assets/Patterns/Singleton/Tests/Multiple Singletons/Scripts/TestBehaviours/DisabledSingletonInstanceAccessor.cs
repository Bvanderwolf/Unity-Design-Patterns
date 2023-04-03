using System;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
    public class DisabledSingletonInstanceAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertNonExistence("Awake");
            AssertInvalidInstance("Awake");
        }

        private void Start()
        {
            AssertNonExistence("Start");
            AssertInvalidInstance("Start");
        }

        private void OnEnable()
        {
            AssertNonExistence("OnEnable");
            AssertInvalidInstance("OnEnable");
        }

        private static void AssertNonExistence(string method)
        {
            Assert.IsFalse(DisabledSingleton.Exists, $"[DisabledSingletonInstanceAccessor.{method}]");
        }

        private static void AssertInvalidInstance(string method)
        {
            try
            {
                DisabledSingleton.Instance.Use();
                Assert.Fail($"[DisabledSingletonInstanceAccessor.{method}]");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, ExceptionMessages.GetFor<DisabledSingleton>(ExceptionMessage.DISABLED_SINGLETON));
            }
        }
    }
}