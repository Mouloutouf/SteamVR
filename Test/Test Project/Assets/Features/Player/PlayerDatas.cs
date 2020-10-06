using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class PlayerDatas : MonoBehaviour
    {
        [SerializeField] private Vector3Variable playerPosition;
        [SerializeField] private GameEvent OnPlayerMove;

        // Update is called once per frame
        void Update()
        {
            if (transform.position != playerPosition.Value)
            {
                playerPosition.SetValue(transform.position);
                OnPlayerMove.Raise();
            }
            
        }
    }
}

