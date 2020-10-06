using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cameras move from left to right by default. Set the "isResetting" bool to true on start to get opposite movement
public class RotationData : MonoBehaviour
{
    protected bool isRotating = true;
    protected bool isResetting = false;
    protected float rotationAngle = 90;
    protected float rotationDuration = 3f;
    protected float waitDuration = 1f;
}
