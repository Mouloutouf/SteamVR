using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay.Mobile
{
    public class MovePlayerMobile : MonoBehaviour
    {
        [SerializeField] private Vector3Variable playerVRPosition;
        [SerializeField] private RectTransform playerMobileRect;
        [SerializeField] private RectTransform canvasRect;
        [SerializeField] private Camera cam;
        private Vector3 viewportCoefs;

        void Start()=> viewportCoefs = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        void Update()
        {
            playerMobileRect.anchoredPosition =
                new Vector2(-(canvasRect.sizeDelta.x / 2 / viewportCoefs.x) * playerVRPosition.Value.x,- (canvasRect.sizeDelta.y / 2 / viewportCoefs.z) *playerVRPosition.Value.z);
        }
    }
}

