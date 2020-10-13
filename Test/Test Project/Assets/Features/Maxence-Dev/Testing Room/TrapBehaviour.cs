using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.VR;

public class TrapBehaviour : MonoBehaviour
{
    public GameEvent loseEvent;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") loseEvent.Raise();
    }
}
