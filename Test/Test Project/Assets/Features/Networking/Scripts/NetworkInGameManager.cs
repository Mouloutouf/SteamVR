using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GamePlay
{
    public class NetworkInGameManager : MonoBehaviour
    {
        [SerializeField] private PhotonView photonView;
        [SerializeField] private Vector3Variable playerPosition;
        [SerializeField] private GameObject terrainPrefab;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject canvasMinMapPrefab;

        private void Start()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                InstantiatePrefabs(terrainPrefab, Vector3.zero);
                InstantiatePrefabs(playerPrefab, new Vector3(0,0.6f,0));

            }
            else
            {
                InstantiatePrefabs(canvasMinMapPrefab, Vector3.zero);
            }
        }
        public void SharePlayerPosition()
        {
            if (Application.platform != RuntimePlatform.Android)
                photonView.RPC("SharePlayerPositionPun", RpcTarget.Others, playerPosition.Value);
        }

        [PunRPC]

        private void SharePlayerPositionPun(Vector3 playerPos)
        {
            playerPosition.Value = playerPos;
        }

        public void InstantiatePrefabs(GameObject prefab, Vector3 position)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}

