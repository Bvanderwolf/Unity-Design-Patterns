using System;
using BWolf.Patterns.Singleton.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
   public class MissingSingletonInstanceAccessor : MonoBehaviour
   {
      private void Awake()
      {
         AssertNonExistence("Awake");
         AssertInAccessibleInstance("Awake");
      }
      
      private void Start()
      {
         AssertNonExistence("Start");
         AssertInAccessibleInstance("Start");
      }
      
      private void OnEnable()
      {
         AssertNonExistence("OnEnable");
         AssertInAccessibleInstance("OnEnable");
      }

      private static void AssertNonExistence(string method)
      {
         Assert.IsFalse(MissingSingleton.Exists, $"[MissingSingletonInstanceAccessor.{method}]");
      }

      private static void AssertInAccessibleInstance(string method)
      {
         try
         {
            MissingSingleton.Instance.Use();
            Assert.Fail($"[MissingSingletonInstanceAccessor.{method}]");
         }
         catch (InvalidOperationException e)
         {
            Assert.AreEqual(e.Message,
               ExceptionMessages.GetFor<MissingSingleton>(ExceptionMessage.MISSING_BOOT_INFO));
         }
      }
   }
}
