using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBallistixBehavior : GuardBallistixData
{
    public GuardBallistixManager manager;
    
    private void Shot()
    {
        manager.deadGuard = this;

        Debug.Log("I've been shot");
        guardShot.Raise();
        gameObject.SetActive(false);
        //transform.Rotate(new Vector3(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
}
