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
        [SerializeField] private GameEvent _OnSwitchBlueCurrentPressed;
        [SerializeField] private GameEvent _OnSwitchRedCurrentPressed;
        [SerializeField] private GameEvent _OnSwitchGreenCurrentPressed;

        public void TransmitWinToAll()=> photonView.RPC("TransmitWin", RpcTarget.All);
        [PunRPC]
        private void TransmitWin() => _OnWin.Raise();
        public void TransmitLooseToAll()=> photonView.RPC("TransmitLoose", RpcTarget.All);
        [PunRPC]
        private void TransmitLoose() => _OnLoose.Raise();
        public void TransmitPlayerPositionToOthers()=> photonView.RPC("TransmitPlayerPosition", RpcTarget.Others, playerPosition.Value);
        [PunRPC]
        private void TransmitPlayerPosition(Vector3 position) => playerPosition.Value = position;
        public void TransmitRedCurrentToAll() => photonView.RPC("TransmitRedCurrent", RpcTarget.All);

        [PunRPC]
        private void TransmitRedCurrent() => _OnSwitchRedCurrentPressed.Raise();
        
        public void TransmitBlueCurrentToAll() => photonView.RPC("TransmitBlueCurrent", RpcTarget.All);

        [PunRPC]
        private void TransmitBlueCurrent() => _OnSwitchBlueCurrentPressed.Raise();
        public void TransmitGreenCurrentToAll() => photonView.RPC("TransmitGreenCurrent", RpcTarget.All);

        [PunRPC]
        private void TransmitGreenCurrent() => _OnSwitchGreenCurrentPressed.Raise();
    }
}

