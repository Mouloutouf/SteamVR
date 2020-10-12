using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

namespace Gameplay.VR
{
    public class ProjectileBehaviour : ProjectileData
    {
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            SetInactive();
        }

        public void Launch()
        {
            transform.position = gunBarrel.transform.position;
            transform.rotation = gunBarrel.transform.rotation;

            gameObject.SetActive(true);

            rb.AddRelativeForce(Vector3.forward * bulletForce.Value, ForceMode.VelocityChange);

            StartCoroutine(LifetimeDecay());
        }

        private IEnumerator LifetimeDecay()
        {
            yield return new WaitForSeconds(bulletLifetime.Value);

            returnedToPool.Raise();

            SetInactive();
        }

        public void SetInactive()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            gameObject.SetActive(false);
        }
    }
}