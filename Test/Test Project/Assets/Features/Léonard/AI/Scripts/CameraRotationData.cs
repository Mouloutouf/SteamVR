using GamePlay;
using UnityEngine;

namespace Gameplay.VR
{
    // Cameras move from left to right by default. Set the "isResetting" bool to true on start to get opposite movement
    public class CameraRotationData : MonoBehaviour
    {
        [SerializeField] protected FloatVariable rotationAngle;
        [SerializeField] protected FloatVariable rotationDuration;
        [SerializeField] protected FloatVariable waitDuration;
        [SerializeField] protected bool isRotating;
        [SerializeField] protected bool isResetting;
        protected Transform baseRotation;
    }
}