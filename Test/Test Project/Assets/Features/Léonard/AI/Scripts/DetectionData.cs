using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionData : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] protected BoolVariable isActive;
    [SerializeField] protected BoolVariable detectedPlayer;
    [SerializeField] protected FloatVariable detectionAngle;
    [SerializeField] protected FloatVariable detectionSpeed;
}
