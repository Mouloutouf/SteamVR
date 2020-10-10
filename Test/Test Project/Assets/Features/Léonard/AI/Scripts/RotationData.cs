using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cameras move from left to right by default. Set the "isResetting" bool to true on start to get opposite movement
public class RotationData : MonoBehaviour
{
    [SerializeField] protected BoolVariable isRotating;
    [SerializeField] protected BoolVariable isResetting;
    [SerializeField] protected FloatVariable rotationAngle;
    [SerializeField] protected FloatVariable rotationDuration;
    [SerializeField] protected FloatVariable waitDuration;
}
