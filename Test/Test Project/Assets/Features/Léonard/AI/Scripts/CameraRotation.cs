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

    // Loops a camera "Sweeping" motion over a set angle
    IEnumerator ScanArea()
    {
        while(true)
        {
            float change;
            float time = 0;
            float startPosition;

            if (isResetting)
            {
                startPosition = rotationAngle; // move from right to left
                change = -rotationAngle;
            }

            else
            {
                startPosition = 0; // move from left to right
                change = rotationAngle;
            }

            while (time <= rotationDuration)
            {
                time += Time.deltaTime;
                
                var rotationAmount = TweenManager.LinearTween(time, startPosition, change, rotationDuration);
                transform.rotation  = Quaternion.Euler(0, rotationAmount, 0);

                yield return null;
            }

            isResetting = !isResetting; // set the bool to its inverse value to start rotating to initial position

            yield return new WaitForSeconds(waitDuration);
        }
    }
}
