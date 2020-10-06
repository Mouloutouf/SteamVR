using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Mobile
{
    public class PlayerMiniMapMovement : MonoBehaviour
    {

        [SerializeField] private RectTransform playerMiniMapRect;
        [SerializeField] private Vector3Variable playerPosition;

        private void Update()
        {
            ChangePlayerMiniMapPosition(playerPosition);
        }
        public void ChangePlayerMiniMapPosition(Vector3Variable position)
        {
            playerMiniMapRect.anchoredPosition = new Vector3(position.Value.x * 10, position.Value.z * 10);
        }
    }
}

