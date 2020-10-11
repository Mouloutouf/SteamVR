using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Mobile
{
    [Serializable]
    public class ElectricElement
    {
        public GameObject gameObject;

        public bool isPowered { get => gameObject.activeSelf; }
    }

    public class ElectricNode : MonoBehaviour
    {
        public List<ElectricElement> positiveElements;

        public List<ElectricElement> negativeElements;
        
        private bool poweredPositive;

        public void SwitchCurrent()
        {
            poweredPositive = !poweredPositive;

            foreach (ElectricElement element in positiveElements) element.gameObject.SetActive(poweredPositive);

            foreach (ElectricElement element in negativeElements) element.gameObject.SetActive(!poweredPositive);
        }

        void Start()
        {
            poweredPositive = false;

            SwitchCurrent();
        }
    }
}
