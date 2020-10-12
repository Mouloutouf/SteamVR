﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu(menuName = "Atom Variables/String Variable")]
    public class StringVariable : ScriptableObject
    {
        public string Value;

        public void SetValue(string value) => Value = value;
    }
}

