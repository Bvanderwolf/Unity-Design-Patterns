using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BWolf.Patterns.Singleton.Tests.MultipleSingletons
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField]
        private float _interval = 2.0f;

        [SerializeField]
        private string _newScene = "SingletonInstantiationScene";

        private static string _initialScene;
        
        private void Awake()
        {
            if (string.IsNullOrEmpty(_initialScene))
                _initialScene = SceneManager.GetActiveScene().name;
            if (SceneManager.GetActiveScene().name == _initialScene)
                StartCoroutine(LoadSceneAfterInterval(_newScene));
            else
                StartCoroutine(LoadSceneAfterInterval(_initialScene));
        }

        private IEnumerator LoadSceneAfterInterval(string scene)
        {
            yield return new WaitForSecondsRealtime(_interval);

            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
