using GamePlay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.VR
{
    public class GunManager : MonoBehaviour
    {
        protected ProjectilePool projectilePool = null;

        [SerializeField] protected GameObject projectilePrefab;
        [SerializeField] Transform gunBarrelTransform;

        [SerializeField] protected FloatVariable poolSize;
        [SerializeField] protected FloatVariable reloadTime;
        [SerializeField] protected FloatVariable maxAmmunition;
        [SerializeField] protected int firedCount;

        [SerializeField] protected Text ammoText;

        [SerializeField] protected bool isReloading;

        RaycastHit hitInfo;
        LayerMask layerMask;

        private void Awake()
        {
            projectilePool = new ProjectilePool(projectilePrefab, (int)poolSize.Value, gunBarrelTransform);
        }

        private void Start()
        {
            UpdateFireCount(0);
        }

        public void GE_Fire()
        {
            if (!isReloading)
            {
                if (firedCount >= maxAmmunition.Value) return; // if you're firing more than what's in the pool, cancel the fire function

                else
                {
                    projectilePool.projectiles[firedCount].Launch();
                    UpdateFireCount(++firedCount);
                }
            }
        }

        public void GE_Reload()
        {
            isReloading = true;
            StartCoroutine(ReloadGun());
        }

        private IEnumerator ReloadGun()
        {
            if (firedCount == 0) yield break;

            yield return new WaitForSeconds(reloadTime.Value);
            isReloading = false;
            firedCount = 0;

            UpdateFireCount(0);
        }

        public void GE_ReturnedToPool()
        {
            //firedCount--;
        }

        void UpdateFireCount(float value)
        {
            ammoText.text = (maxAmmunition.Value - value).ToString();
        }
    }
}
