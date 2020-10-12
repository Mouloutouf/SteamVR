using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR
{
    public class ProjectileData : MonoBehaviour
    {
        [SerializeField] protected FloatVariable bulletForce;
        [SerializeField] protected FloatVariable bulletLifetime;
        [SerializeField] protected GameEvent returnedToPool;
                
        internal Transform gunBarrel; // accessed by GunManager and PoolManager
        protected Rigidbody rb; // accessed in Awake method of ProjectileBehavior
    }
}