using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu]
    public class BoolVariable : ScriptableObject
    {
        public bool Value;

        public void SetValue(bool value)
        {

            Value = value;

        }

    }
}

