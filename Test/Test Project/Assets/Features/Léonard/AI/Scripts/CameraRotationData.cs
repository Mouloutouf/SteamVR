using GamePlay;
using UnityEngine;

namespace Gameplay.VR
{
    // Cameras move from left to right by default. Set the "isResetting" bool to true on start to get opposite movement
    public class CameraRotationData : MonoBehaviour
    {
        [SerializeField] protected BoolVariable isRotating;
        [SerializeField] protected BoolVariable isResetting;
        [SerializeField] protected FloatVariable rotationAngle;
        [SerializeField] protected FloatVariable rotationDuration;
        [SerializeField] protected FloatVariable waitDuration;
        protected Transform baseRotation;
    }
}