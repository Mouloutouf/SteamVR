﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.VR
{
    public class PlayerVRDatas : MonoBehaviour
    {
        [SerializeField] private GameEvent _OnPlayermove;
        [SerializeField] private Vector3Variable playerPosition;
        [SerializeField] private GameObjectVariable player;
        private Vector3 positionReminder;

        private void Start()
        {
            player.Value = this.gameObject;
        }
        private void Update()
        {
            if (positionReminder != transform.position)
            {
                playerPosition.Value = transform.position;
                _OnPlayermove.Raise();
            }

        }
    }

}
