using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.VR
{
    public class AgentAwarenessBehavior : AgentAwarenessData
    {
        [SerializeField] internal bool spottedPlayer;
        RaycastHit hitInfo;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player"); // find a better way to do this
            spotLight = GetComponentInChildren<Light>();
            spotLight.spotAngle = detectionAngle.Value;
            myDetectionAngle = detectionAngle.Value * 0.5f;

            isActive = baseState.Value;
            if (isActive) StartCoroutine(DetectPlayer()); // divide by two because the check is doubled in size
        }

        public void GE_SwitchElectricalCurrent()
        {
            isActive = !isActive;
            if (isActive) StartCoroutine(DetectPlayer());
            else
            {
                spotLight.intensity = 0;
                StopAllCoroutines();
            }
        }

        private IEnumerator DetectPlayer()
        {
            spotLight.intensity = 2.5f;

            while (true)
            {
                // DEBUG INFORMATION - REMOVE IN FINAL BUILD
                Vector3 forward = transform.forward;
                forward.y = 0;
                Debug.DrawRay(transform.position, forward * detectionRange.Value);

                if (spottedPlayer)
                {
                    yield return new WaitForSeconds(detectionSpeed.Value);

                    // if the player is still inside your cone of vision
                    if (Vector3.Angle(target.transform.position - transform.position, transform.forward) <= myDetectionAngle)
                    {
                        Debug.Log(gameObject.name + " has detected the player");
                        Debug.DrawLine(transform.position, target.transform.position, Color.green);
                        detectedPlayer.Raise();
                        break;
                    }

                    else
                    {
                        Debug.Log("Must have been nothing");
                        spottedPlayer = false;
                    }
                }

                // check if player is within the AI's "depth" range
                else if (Vector3.Distance(new Vector3(target.transform.position.x, 0, target.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z)) < detectionRange.Value)
                {
                    Debug.DrawLine(transform.position, target.transform.position, Color.green);

                    Vector3 targetDir = target.transform.position - transform.position;

                    float angleDifference = Vector3.Angle(targetDir, transform.forward);

                    // returns true if the angle between the two is less than the detection angle
                    bool playerInSight = angleDifference <= myDetectionAngle ? true : false;

                    if (playerInSight)
                    {
                        Debug.Log("Is that the player ");

                        // if there is something between the AI and the player
                        if (Physics.Linecast(transform.position, target.transform.position, out hitInfo, layerMask))
                        {
                            Debug.Log(gameObject.name + " hit " + hitInfo.collider.gameObject.name);
                            spottedPlayer = true;
                        }

                        else Debug.Log(gameObject.name + " is hitting nothing");;
                    }
                }

                yield return null;
            }
        }
    }
}