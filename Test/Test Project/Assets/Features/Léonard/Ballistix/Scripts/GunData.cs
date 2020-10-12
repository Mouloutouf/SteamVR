using GamePlay;
using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Gameplay.VR
{
    public class GunData : MonoBehaviour
    {
        [SerializeField] protected SteamVR_Action_Boolean fireActionBool = null;
        [SerializeField] protected SteamVR_Action_Boolean reloadActionBool = null;
        [SerializeField] protected SteamVR_Behaviour_Pose behaviorPose = null;

        [SerializeField] protected GameEvent fireGun;
        [SerializeField] protected GameEvent reloadGun;

        [SerializeField] protected FloatVariable ammoCount;

        [SerializeField] protected bool isReloading;

        [SerializeField] protected ControllerButton fireButton;
        [SerializeField] protected HandRole fireHand;

        [SerializeField] protected ControllerButton reloadButton;
        [SerializeField] protected HandRole reloadHand;
    }
}