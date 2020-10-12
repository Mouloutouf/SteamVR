using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Gameplay.VR.Testing
{
    public class TargetBehavior : MonoBehaviour
    {
        public TargetManager targetManager;
        public float waitTime;

        // Start is called before the first frame update
        void Start()
        {
            targetManager.allTargets.Add(gameObject);
        }


        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile")) StartCoroutine(SetInactive());
        }

        private IEnumerator SetInactive()
        {
            gameObject.SetActive(false);
            targetManager.inactiveTargets.Add(gameObject);

            yield return new WaitForSeconds(waitTime);

            gameObject.SetActive(true);
        }
    }
}
