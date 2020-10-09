using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NetworkMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject createRoom;
    [SerializeField] private GameObject joinRoom;
    
    public void SetupCompareToApplication()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            joinRoom.SetActive(true);
        }
        else
        {
            createRoom.SetActive(true);
        }
    }
}
