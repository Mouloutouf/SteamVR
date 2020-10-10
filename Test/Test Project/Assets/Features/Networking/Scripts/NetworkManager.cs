using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace GamePlay.Network
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameEvent _OnConnectedToServer;
        [SerializeField] private GameEvent _OnJoindRoomFailed;
        [SerializeField] private GameEvent _OnRoomFull;
        private void Start() => ConnectToServer();
        private void ConnectToServer() => PhotonNetwork.ConnectUsingSettings();

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom("1");
        }

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
            PhotonNetwork.CreateRoom("1", roomOptions);
            
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                _OnRoomFull.Raise();
            }
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            _OnJoindRoomFailed.Raise();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            _OnRoomFull.Raise();
            Debug.Log("full");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log(PhotonNetwork.CloudRegion);
            PhotonNetwork.AutomaticallySyncScene = true;
            _OnConnectedToServer.Raise();
        }

        private void Update()
        {
            Debug.Log(PhotonNetwork.CurrentRoom);
        }
    }
}

