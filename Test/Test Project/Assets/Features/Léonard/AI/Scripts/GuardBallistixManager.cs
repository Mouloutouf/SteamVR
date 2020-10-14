using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.Newtonsoft.Json.Linq.JsonPath;

namespace Gameplay.VR
{
    public class GuardBallistixManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> guards = new List<GameObject>();
        [SerializeField] internal GameObject deadGuard = null;
        [SerializeField] protected GameEvent spottedFriendly;
        private RaycastHit hitInfo;

        private void Awake()
        {
            foreach (GuardBallistixBehavior guard in FindObjectsOfType<GuardBallistixBehavior>()) guards.Add(guard.gameObject);
        }

        public void GE_FriendlyDied()
        {
            Debug.Log(deadGuard.transform.position);
            foreach (GameObject guard in guards)
            {
                if(guard != deadGuard)
                {
                    Debug.Log(guard.name + "'s position is " + guard.transform.position);

                    if (Physics.Linecast(guard.transform.position, deadGuard.transform.position, out hitInfo))
                    {
                        if(hitInfo.transform.position == deadGuard.transform.position && Vector3.Angle(deadGuard.transform.position - guard.transform.position, guard.transform.forward) <= 60)
                        {
                            Debug.Log(guard.gameObject.name + " watched a friendly die");
                            spottedFriendly.Raise();
                        }

                        Debug.Log("No one saw that...");
                    }
                }
            }
        }
    }

}

