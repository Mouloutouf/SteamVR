using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : DetectionData
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward * 5, Color.green);

        Vector3 targetDir = target.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle <= detectionAngle) Debug.Log("I can see the player");
    }
}
