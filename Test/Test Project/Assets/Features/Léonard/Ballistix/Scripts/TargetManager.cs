using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR
{
    public class TargetManager : MonoBehaviour
    {
        public List<GameObject> allTargets = new List<GameObject>();
        public List<GameObject> inactiveTargets = new List<GameObject>();
    }
}