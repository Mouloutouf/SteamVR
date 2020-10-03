using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private CamDataBehavior camDataBehavior;
    [SerializeField] private Rotate rotate;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotate.DoRotate(camDataBehavior.camData.speedRotation);
        }
    }
}
