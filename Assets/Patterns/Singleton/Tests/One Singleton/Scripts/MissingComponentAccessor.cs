using System;
using System.Collections.Generic;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.OneSingleton
{
    public class MissingComponentAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertMissingComponentException("Awake");
        }

        private void Start()
        {
            AssertMissingComponentException("Start");
        }

        private void OnEnable()
        {
            AssertMissingComponentException("OnEnable");
        }

        private static void AssertMissingComponentException(string method)
        {
            try
            {
                Singleton.Instance.Use();
                Assert.Fail($"[MissingComponentAccessor.{method}]");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, ExceptionMessages.GetFor<Singleton>(ExceptionMessage.MISSING_BOOT_INFO));
            }
        }
    }
}
