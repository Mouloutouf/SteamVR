using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Gameplay.VR
{
    public class GunBehaviour : GunData
    {
        // Start is called before the first frame update
        void Start()
        {
            behaviorPose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        }

        // Update is called once per frame
        void Update()
        {
            if(ViveInput.GetPressDown(fireHand, fireButton)) fireGun.Raise();
            else if (Input.GetMouseButtonDown(0)) fireGun.Raise();

            if (ViveInput.GetPressDown(reloadHand, reloadButton)) fireGun.Raise();
            else if (Input.GetKeyDown(KeyCode.R)) reloadGun.Raise();

            if (behaviorPose != null && fireActionBool.GetStateDown(behaviorPose.inputSource)) fireGun.Raise();
            if (behaviorPose != null && reloadActionBool.GetStateDown(behaviorPose.inputSource)) reloadGun.Raise();;
        }
    }
}