using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : RotationData
{
    Transform baseRotation;

    void Start()
    {
        baseRotation = transform;
        isResetting.SetValue(false);
        if (isRotating.isTrue()) StartCoroutine(ScanArea());
    }

    // Loops a camera "Sweeping" motion over a set angle
    IEnumerator ScanArea()
    {
        while(true)
        {
            float change;
            float time = 0;
            float startPosition;

            if (isResetting.isTrue())
            {
                startPosition = rotationAngle.Value; // move from right to left
                change = -rotationAngle.Value;
            }

            else
            {
                startPosition = 0; // move from left to right
                change = rotationAngle.Value;
            }

            while (time <= rotationDuration.Value)
            {
                time += Time.deltaTime;
                
                var rotationAmount = TweenManager.LinearTween(time, startPosition, change, rotationDuration.Value);
                transform.rotation  = Quaternion.Euler(baseRotation.localRotation.eulerAngles.x, rotationAmount, baseRotation.localRotation.eulerAngles.z);

                yield return null;
            }

            isResetting.SetValue(!isResetting.Value); // set the bool to its inverse value to start rotating to initial position

            yield return new WaitForSeconds(waitDuration.Value);
        }
    }
}
