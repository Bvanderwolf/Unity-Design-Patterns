using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.ZeroSingletons
{
    public class SingletonBootstrapInfoAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertFirstSceneLoaded("Awake");
            AssertProfileWithSingletons("Awake");
        }

        private void Start()
        {
            AssertFirstSceneLoaded("Start");
            AssertProfileWithSingletons("Start");
        }

        private void OnEnable()
        {
            AssertFirstSceneLoaded("OnEnable");
            AssertProfileWithSingletons("OnEnable");
        }

        private static void AssertFirstSceneLoaded(string method)
        {
            Assert.AreEqual(SingletonBootstrapInfo.FirstSceneLoaded.name, "ZeroSingletonScene", $"[SingletonBootstrapInfoAccessor.{method}]");
        }

        private static void AssertProfileWithSingletons(string method)
        {
            Assert.IsFalse(SingletonBootstrapInfo.HasProfileWithSingletons(), $"[SingletonBootstrapInfoAccessor.{method}]");
        }
    }
}
