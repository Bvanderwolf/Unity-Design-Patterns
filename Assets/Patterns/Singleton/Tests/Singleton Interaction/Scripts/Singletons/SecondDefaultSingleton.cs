using System;
using System.Collections;
using System.Collections.Generic;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.SingletonInteraction
{
    public class SecondDefaultSingleton : SingletonBehaviour<SecondDefaultSingleton>
    {
        protected override void Awake()
        {
            base.Awake();
            AssertAccessibleInstance(FirstDefaultSingleton.Instance, "Awake");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "Awake");
            AssertAccessibleInstance(InitialSceneSingleton.Instance, "Awake");
        }

        private void OnEnable()
        {
            AssertAccessibleInstance(FirstDefaultSingleton.Instance, "OnEnable");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "OnEnable");
            AssertAccessibleInstance(InitialSceneSingleton.Instance, "OnEnable");
        }

        private void Start()
        {
            AssertAccessibleInstance(FirstDefaultSingleton.Instance, "Start");
            AssertAccessibleInstance(ThirdDefaultSingleton.Instance, "Start");
            AssertAccessibleInstance(InitialSceneSingleton.Instance, "Start");
        }
        
        public void Use()
        {
            
        }

        private static void AssertAccessibleInstance<T>(SingletonBehaviour<T> instance, string method) where T : MonoBehaviour
        {
            Assert.IsNotNull(instance, $"[SecondDefaultSingleton.{method}]");
        }
    }
}