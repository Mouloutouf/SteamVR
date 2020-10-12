using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR
{
    public class ProjectileBehaviour : ProjectileData
    {
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Launch()
        {
            transform.localPosition = gunBarrel.localPosition;
            transform.localRotation = gunBarrel.localRotation;

            rb.AddRelativeForce(Vector3.forward * bulletForce.Value, ForceMode.Impulse);

            StartCoroutine(Lifetime());
        }

        private IEnumerator Lifetime()
        {
            new WaitForSeconds(bulletLifeTime.Value);
            yield return null;
        }
    }
}