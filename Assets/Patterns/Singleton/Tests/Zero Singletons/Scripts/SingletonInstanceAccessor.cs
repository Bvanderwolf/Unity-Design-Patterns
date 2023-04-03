using System;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.ZeroSingletons
{
    public class SingletonInstanceAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertNonExistence("Awake");
            AssertInvalidProfileException("Awake");
        }

        private void Start()
        {
            AssertNonExistence("Start");
            AssertInvalidProfileException("Start");
        }

        private void OnEnable()
        {
            AssertNonExistence("OnEnable");
            AssertInvalidProfileException("OnEnable");
        }

        private static void AssertInvalidProfileException(string method)
        {
            try
            {
                Singleton.Instance.Use();
                Assert.Fail($"[SingletonInstanceAccessor.{method}]");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, ExceptionMessages.GetFor<Singleton>(ExceptionMessage.INVALID_PROFILE));
            }
        }

        private static void AssertNonExistence(string method)
        {
            Assert.IsFalse(Singleton.Exists, $"[SingletonInstanceAccessor.{method}]");
        }
    }
}
