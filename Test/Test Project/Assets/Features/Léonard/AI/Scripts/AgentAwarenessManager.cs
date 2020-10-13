using Gameplay.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manages incoming detectingPlayer events
public class AgentAwarenessManager : MonoBehaviour
{
    [SerializeField] List<AgentAwarenessBehavior> entities = new List<AgentAwarenessBehavior>();
    [SerializeField] List<CameraRotationBehavior> mobileCameras = new List<CameraRotationBehavior>();

    [SerializeField] Text gameOver;

    private void Start()
    {
        gameOver.enabled = false;
        foreach (AgentAwarenessBehavior awareEntity in FindObjectsOfType<AgentAwarenessBehavior>()) entities.Add(awareEntity);
        foreach (CameraRotationBehavior mobileCamera in FindObjectsOfType<CameraRotationBehavior>()) mobileCameras.Add(mobileCamera);
    }

    public void GE_GuardDetectingPlayer()
    {
        gameOver.enabled = true;
        gameOver.text = "Game Over : \n Guard spotted you";
    }

    public void GE_CameraDetectingPlayer()
    {
        gameOver.enabled = true;
        gameOver.text = "Game Over : \n Camera spotted you";
    }
}
