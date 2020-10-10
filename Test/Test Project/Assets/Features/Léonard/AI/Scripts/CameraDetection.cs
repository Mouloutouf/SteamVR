using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : DetectionData
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        StartCoroutine(DetectPlayer(detectionAngle.Value * 0.5f));
    }

    private IEnumerator DetectPlayer(double detectionAngle)
    {
        while (true)
        {
            float dist = Vector3.Distance(new Vector3(target.transform.position.x, 0, target.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z));
            print("Distance to other: " + dist);

            // check if player is within the camera's "depth" range
            if (Vector3.Distance(new Vector3(target.transform.position.x, 0, target.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z)) < detectionRange.Value)
            {
                Vector3 targetDir = target.transform.position - transform.position;

                float angleDifference = Vector3.Angle(targetDir, transform.forward);

                // returns true if the angle between the two is less than the detection angle
                bool detectedPlayer = angleDifference <= detectionAngle ? true : false;

                if (detectedPlayer)
                {
                    Debug.Log("I can see the player");
                    Debug.DrawLine(transform.position, target.transform.position, Color.blue);
                }
            }

            yield return null;
        }
    }
}
