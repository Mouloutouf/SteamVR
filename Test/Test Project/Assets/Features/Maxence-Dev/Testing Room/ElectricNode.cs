using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Mobile
{
    [Serializable]
    public class ElectricElement
    {
        public GameObject gameObject;

        public bool isPowered { get => gameObject.activeSelf; }

        public bool isNode;
    }

    public class ElectricNode : MonoBehaviour
    {
        public List<ElectricElement> positiveElements;

        public List<ElectricElement> negativeElements;
        
        public GameEvent onSwitchEvent;

        private bool poweredPositive;

        private bool timedSwitchActivated;
        private float timeToWait;
        public Text timeDisplay;

        public Button switchButton;

        public void SwitchCurrent()
        {
            poweredPositive = !poweredPositive;

            foreach (ElectricElement element in positiveElements)
                if (element.isNode) element.gameObject.GetComponent<ElectricNode>().CurrentAll(poweredPositive);
                else element.gameObject.SetActive(poweredPositive);

            foreach (ElectricElement element in negativeElements)
                if (element.isNode) element.gameObject.GetComponent<ElectricNode>().CurrentAll(!poweredPositive);
                else element.gameObject.SetActive(!poweredPositive);

            onSwitchEvent.Raise();
        }

        public void SwitchCurrent(float time)
        {
            timedSwitchActivated = true;
            timeToWait = time;

            timeDisplay.gameObject.SetActive(true);
            switchButton.interactable = false;

            SwitchCurrent();
        }

        // IEnumerator SwitchAndWait(float _time)
        // {
        //     SwitchCurrent();

        //     yield return new WaitForSeconds(_time);

        //     SwitchCurrent();
        // }

        public void CurrentAll(bool mainPower)
        {
            if (!mainPower)
            {
                List<GameObject> poweredObjects = new List<GameObject>();

                foreach (ElectricElement element in positiveElements) poweredObjects.Add(element.gameObject);
                foreach (ElectricElement element in negativeElements) poweredObjects.Add(element.gameObject);

                foreach(GameObject poweredObject in poweredObjects)
                {
                    poweredObject.SetActive(mainPower);
                }

                switchButton.interactable = false;
            }
            else
            {
                poweredPositive = !poweredPositive;
                SwitchCurrent();

                switchButton.interactable = true;
            }
        }

        void Start()
        {
            poweredPositive = false;

            timeDisplay.gameObject.SetActive(false);

            SwitchCurrent();
        }

        void Update()
        {
            if (timedSwitchActivated) DisplayTime();
        }

        void DisplayTime()
        {
            if (timeToWait <= 0.0f)
            {
                timedSwitchActivated = false;

                timeDisplay.gameObject.SetActive(false);
                switchButton.interactable = true;

                SwitchCurrent();
            }

            timeToWait -= Time.deltaTime;
            double timeToDisplay = Math.Round(timeToWait, 1);

            timeDisplay.text = timeToDisplay.ToString();
        }
    }
}
