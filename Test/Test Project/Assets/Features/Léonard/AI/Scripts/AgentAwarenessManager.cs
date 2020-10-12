using Gameplay.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages incoming detectingPlayer events
public class AgentAwarenessManager : MonoBehaviour
{
    [SerializeField] List<AgentAwarenessBehavior> entities = new List<AgentAwarenessBehavior>();
    [SerializeField] List<CameraRotationBehavior> cameras = new List<CameraRotationBehavior>();

    private void Start()
    {
        foreach (AgentAwarenessBehavior awareEntity in FindObjectsOfType<AgentAwarenessBehavior>()) entities.Add(awareEntity);
        foreach (CameraRotationBehavior rotateCamera in FindObjectsOfType<CameraRotationBehavior>()) cameras.Add(rotateCamera);
    }

    public void GE_GuardDetectingPlayer()
    {

    }

    public void GE_CameraDetectingPlayer()
    {
        // if a cacmera that had detected the pllayer raises the missing event
        foreach (AgentAwarenessBehavior entity in entities)
        {
            if (entity.spottedPlayer == true)
            {

            }
        }
    }
}
