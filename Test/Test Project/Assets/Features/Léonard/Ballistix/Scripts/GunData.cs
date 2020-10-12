using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Gameplay.VR
{
    public class GunData : MonoBehaviour
    {
        [SerializeField] protected SteamVR_Action_Boolean fireAction = null;
        [SerializeField] protected SteamVR_Action_Boolean reloadAction = null;
        [SerializeField] protected SteamVR_Behaviour_Pose pose = null;
        [SerializeField] protected FloatVariable ammoCount;
        [SerializeField] protected GameEvent fireGun;
        [SerializeField] protected GameEvent reloadGun;
    }
}