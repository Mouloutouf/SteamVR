using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : RotationData
{
    private float startingPosition;

    void Start()
    {
        if (isRotating) StartCoroutine(ScanArea());
    }

    IEnumerator ScanArea()
    {
        while(true)
        {
            float change = 0;
            float time = 0;

            if (isResetting) change = -rotationAngle; // move from right to left
            else change = rotationAngle; // move from left to right

            while (time <= rotationDuration)
            {
                time += Time.deltaTime;
                
                var rotationAmount = TweenManager.LinearTween(time, startingPosition, change, rotationDuration);
                transform.rotation  = Quaternion.Euler(0, rotationAmount, 0);
                yield return null;
            }

            yield return new WaitForSeconds(waitDuration);
            startingPosition = transform.localPosition.y;
            isResetting = !isResetting; // set the bool to its inverse value to start rotating to initial position

        }
    }
}
