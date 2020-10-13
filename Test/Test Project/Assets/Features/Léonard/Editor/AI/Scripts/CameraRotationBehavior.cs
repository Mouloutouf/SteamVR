using System.Collections;
using UnityEngine;

namespace Gameplay.VR
{
    public class CameraRotationBehavior : CameraRotationData
    {
        void Start()
        {
            isResetting = false;
            baseRotation = transform;
            if (isRotating) StartCoroutine(ScanArea());
        }

        public void GE_SwitchElectricalCurrent()
        {
            isRotating = !isRotating;
            if (isRotating) StartCoroutine(ScanArea());
            else StopCoroutine(ScanArea());
        }

        // Loops a camera "Sweeping" motion over a set angle
        IEnumerator ScanArea()
        {
            while (true)
            {
                float change;
                float time = 0;
                float startPosition;

                // move back to starting position
                if (isResetting)
                {
                    startPosition = transform.localRotation.eulerAngles.y;
                    change = -rotationAngle.Value; // move from right to left
                }

                // move to rotate position
                else
                {
                    startPosition = baseRotation.localRotation.eulerAngles.y;
                    change = rotationAngle.Value; // move from left to right
                }

                while (time <= rotationDuration.Value)
                {
                    time += Time.deltaTime;

                    var rotationAmount = TweenManager.LinearTween(time, startPosition, change, rotationDuration.Value);
                    transform.localRotation = Quaternion.Euler(baseRotation.localRotation.eulerAngles.x, rotationAmount, baseRotation.localRotation.eulerAngles.z);

                    yield return null;
                }

                isResetting = !isResetting; // set the bool to its inverse value to start rotating to initial position

                yield return new WaitForSeconds(waitDuration.Value);
            }
        }       
    }
}