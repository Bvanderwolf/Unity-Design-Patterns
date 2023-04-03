using System;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.OneSingleton
{
    public class MissingPrefabAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertMissingPrefabException("Awake");
        }

        private void Start()
        {
            AssertMissingPrefabException("Start");
        }

        private void OnEnable()
        {
            AssertMissingPrefabException("OnEnable");
        }

        private static void AssertMissingPrefabException(string method)
        {
            try
            {
                Singleton.Instance.Use();
                Assert.Fail($"[MissingPrefabAccessor.{method}]");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, ExceptionMessages.Get(ExceptionMessage.MISSING_PREFAB, 0, "MissingPrefabProfile"));
            }
        }
    }
}
