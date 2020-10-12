using GamePlay;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Gameplay.VR
{
    public class GunManager : MonoBehaviour
    {
        [SerializeField] protected GameObject projectilePrefab;
        [SerializeField] protected FloatVariable poolSize;
        protected ProjectilePool projectilePool = null;
        protected int firedCount;
        [SerializeField] Transform gunBarrelTransform;

        private void Awake()
        {
            projectilePool = new ProjectilePool(projectilePrefab, (int)poolSize.Value, gunBarrelTransform);
        }

        public void Fire()
        {
            if (firedCount >= poolSize.Value) return; // if you're firing more than what's in the pool, cancel the fire function
            
            else
            {
                projectilePool.projectiles[firedCount].Launch();
                firedCount++; //increment so that the next time you fire it's the next bullet in the pool
            }
        }

        public void Reload()
        {
            StartCoroutine(ReloadGun());
        }

        private IEnumerator ReloadGun()
        {
            yield return null;
        }
    }
}
