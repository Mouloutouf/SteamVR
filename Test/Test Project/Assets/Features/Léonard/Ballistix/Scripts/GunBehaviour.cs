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
            pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        }

        // Update is called once per frame
        void Update()
        {
            if (pose != null && fireAction.GetStateDown(pose.inputSource)) fireGun.Raise();
            else if (Input.GetMouseButtonDown(0)) fireGun.Raise();

            if (pose != null && reloadAction.GetStateDown(pose.inputSource)) reloadGun.Raise();
            else if (Input.GetKeyDown(KeyCode.R)) reloadGun.Raise();
        }
    }
}