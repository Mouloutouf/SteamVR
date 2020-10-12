using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR
{
    public class ProjectileData : MonoBehaviour
    {
        [SerializeField] protected FloatVariable ammoCount;
        [SerializeField] internal Transform gunBarrel;
        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected FloatVariable bulletForce;
        [SerializeField] protected FloatVariable bulletLifeTime;
    }
}