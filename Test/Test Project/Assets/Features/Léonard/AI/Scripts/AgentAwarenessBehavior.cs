using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Gameplay.VR
{
    public class AgentAwarenessBehavior : AgentAwarenessData
    {
        internal bool spottedPlayer;
        RaycastHit hitInfo;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player"); // find a better way to do this
            spotLight = GetComponentInChildren<Light>();
            spotLight.spotAngle = detectionAngle.Value;
            myDetectionAngle = detectionAngle.Value * 0.5f;
            StartCoroutine(DetectPlayer()); // divide by two because the check is doubled in size
        }

        private IEnumerator DetectPlayer()
        {
            while (true)
            {
                // DEBUG INFORMATION - REMOVE IN FINAL BUILD
                Vector3 forward = transform.forward;
                forward.y = 0;
                Debug.DrawRay(transform.localPosition, forward * detectionRange.Value);

                if (spottedPlayer)
                {
                    yield return new WaitForSeconds(detectionSpeed.Value);

                    // if the player is still inside your cone of vision
                    if (Vector3.Angle(target.transform.localPosition - transform.localPosition, transform.forward) <= myDetectionAngle)
                    {
                        Debug.Log("I have detected the player");
                        Debug.DrawLine(transform.localPosition, target.transform.localPosition, Color.green);
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
                else if (Vector3.Distance(new Vector3(target.transform.localPosition.x, 0, target.transform.localPosition.z), new Vector3(transform.localPosition.x, 0, transform.localPosition.z)) < detectionRange.Value)
                {
                    Vector3 targetDir = target.transform.localPosition - transform.localPosition;

                    float angleDifference = Vector3.Angle(targetDir, transform.forward);

                    // returns true if the angle between the two is less than the detection angle
                    bool playerInSight = angleDifference <= myDetectionAngle ? true : false;

                    if (playerInSight)
                    {
                        // if there is something between the AI and the player
                        if (Physics.Linecast(transform.localPosition, target.transform.localPosition, out hitInfo))
                        {
                            Debug.Log("I've hit " + hitInfo.collider.gameObject.name);
                            yield return null;
                        }

                        Debug.Log("Is that the player...?");
                        spottedPlayer = true;
                    }
                }

                yield return null;
            }
        }
    }
}