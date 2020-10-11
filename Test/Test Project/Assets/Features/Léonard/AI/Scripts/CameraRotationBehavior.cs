using System.Collections;
using UnityEngine;

namespace Gameplay.VR
{
    public class CameraRotationBehavior : CameraRotationData
    {
        void Start()
        {
            baseRotation = transform;
            isResetting.SetValue(false);
            if (isRotating.isTrue()) StartCoroutine(ScanArea());
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
                if (isResetting.isTrue())
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

                isResetting.SetValue(!isResetting.Value); // set the bool to its inverse value to start rotating to initial position

                yield return new WaitForSeconds(waitDuration.Value);
            }
        }

        // called when the player enters the camera's field of view
        public void InterruptRotation()
        {

        }

        public void ActivateCamera()
        {

        }
    }
}