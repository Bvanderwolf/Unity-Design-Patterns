using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
    public class SingletonBootstrapInfoAccessor : MonoBehaviour
    {
        private void Awake()
        {
            AssertHasProfileWithSingletons("Awake");
        }

        private void Start()
        {
            AssertHasProfileWithSingletons("Start");
        }

        private void OnEnable()
        {
            AssertHasProfileWithSingletons("OnEnable");
        }
        
        private static void AssertHasProfileWithSingletons(string method)
        {
            Assert.IsTrue(SingletonBootstrapInfo.HasProfileWithSingletons(), $"[SingletonInstanceAccessor.{method}]");
        }
    }
}
