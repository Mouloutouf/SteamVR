using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR
{
    public class GuardBallistixBehavior : GuardBallistixData
    {
        public GuardBallistixManager manager;

        private void Shot()
        {
            Debug.Log("I've been shot");
            manager.deadGuard = this.gameObject;
            guardShot.Raise();
            gameObject.SetActive(false);
            
            //transform.Rotate(new Vector3(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        }
    }
}