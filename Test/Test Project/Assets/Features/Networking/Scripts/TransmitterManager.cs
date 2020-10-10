using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GamePlay.Network
{
    public class TransmitterManager : MonoBehaviour
    {
        [SerializeField] PhotonView photonView;
        [SerializeField] private Vector3Variable playerPosition;
        [SerializeField] private GameEvent _OnWin;
        [SerializeField] private GameEvent _OnLoose;

        public void TransmitWinToAll()=> photonView.RPC("TransmitWin", RpcTarget.All);
        [PunRPC]
        private void TransmitWin() => _OnWin.Raise();
        public void TransmitLooseToAll()=> photonView.RPC("TransmitLoose", RpcTarget.All);
        [PunRPC]
        private void TransmitLoose() => _OnLoose.Raise();
        public void TransmitPlayerPositionToOthers()=> photonView.RPC("TransmitPlayerPosition", RpcTarget.Others, playerPosition.Value);
        [PunRPC]
        private void TransmitPlayerPosition(Vector3 position) => playerPosition.Value = position;
    }
}

