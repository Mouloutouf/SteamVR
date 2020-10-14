using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR
{
    public class GuardBallistixManager : MonoBehaviour
    {
        [SerializeField] List<GuardBallistixBehavior> guards = new List<GuardBallistixBehavior>();
        [SerializeField] internal GuardBallistixBehavior deadGuard = null;
        [SerializeField] protected GameEvent spottedFriendly;

        private void Awake()
        {
            foreach (GuardBallistixBehavior guard in FindObjectsOfType<GuardBallistixBehavior>()) guards.Add(guard);
        }

        public void GE_FriendlyDied()
        {
            Debug.Log(deadGuard.transform.position);

            foreach (GuardBallistixBehavior guard in guards)
            {
                if (Physics.Linecast(guard.transform.position, deadGuard.transform.localPosition))
                {
                    Debug.Log("No one saw that...");
                    return;
                }

                else
                {
                    Debug.Log(guard.gameObject.name + " watched a friendly die");
                    spottedFriendly.Raise();
                }
            }
        }
    }
}

