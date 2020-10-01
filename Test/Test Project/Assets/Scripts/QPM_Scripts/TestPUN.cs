using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestPUN : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject cube;
    [SerializeField] Material blue;
    [SerializeField] Material red;
    [SerializeField] PhotonView photonView;
    [SerializeField] RoomOptions roomOptions;
    [SerializeField] TypedLobby typedLobby;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }



    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.CloudRegion);
        PhotonNetwork.AutomaticallySyncScene = true;

        if (Input.GetKey(KeyCode.Space))
        {

            RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
            PhotonNetwork.CreateRoom("New Room", roomOptions);
        }
        else
        {
            PhotonNetwork.JoinRoom("New Room");
        }

        
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.JoinRoom("New Room");
    }

    private void Update()
    {
        Debug.Log(PhotonNetwork.CurrentRoom);
        Debug.Log(PhotonNetwork.CountOfRooms);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            photonView.RPC("ChangeColorRed", RpcTarget.AllViaServer);
        }



        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                photonView.RPC("ChangeColorBlue", RpcTarget.AllViaServer);
            }

        }
    }

    [PunRPC]

    public void ChangeColorBlue()
    {
            cube.GetComponent<Renderer>().material = blue;
    }
    [PunRPC]

    public void ChangeColorRed()
    {
            cube.GetComponent<Renderer>().material = red;
    }
}
