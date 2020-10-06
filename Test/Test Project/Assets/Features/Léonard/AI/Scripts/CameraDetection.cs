using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : DetectionData
{
    private bool detectingPlayer, lockingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        StartCoroutine(DetectPlayer());
    }

    private IEnumerator DetectPlayer()
    {
        while (true)
        {
            Debug.DrawLine(transform.position, transform.forward * 5, Color.green);

            Vector3 targetDir = target.transform.position - transform.position;
            float angleDifference = Vector3.Angle(targetDir, transform.forward);

            // returns true if the angle between the two is less than the detection angle
            detectingPlayer = angleDifference <= detectionAngle ? true : false;

            while (detectingPlayer)
            {
                Debug.Log("I might've seen something");

                yield return new WaitForSeconds(detectionSpeed);

                float angleDifference2 = Vector3.Angle(targetDir, transform.forward);
                
                lockingPlayer = angleDifference2 <= detectionAngle ? true : false;

                if (lockingPlayer == true)
                {
                    Debug.Log("Player has been spotted");
                    break;
                }
                else detectingPlayer = false;
            }

            Debug.Log("No Target in Sight");

            yield return null;
        }
    }
}
