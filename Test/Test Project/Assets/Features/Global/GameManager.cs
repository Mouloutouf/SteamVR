using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class GameManager : MonoBehaviour
    {

        private void Start()
        {

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(1, LoadSceneMode.Additive);
            }

        }
    }
}

