using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionData : MonoBehaviour
{
    protected GameObject target;
    protected bool isActive = false;
    protected bool detectedPlayer = false;
    protected float detectionAngle = 90f * 0.5f; // this value needs to be divided by two, as it is the angle on both sides of the transfrom/forward
    protected float detectionSpeed = 0.5f;
}
