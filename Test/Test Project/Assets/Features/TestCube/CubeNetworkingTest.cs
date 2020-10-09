using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CubeNetworkingTest : MonoBehaviour
{
    public MeshRenderer cubeRenderer;
    public Material blue;
    public PhotonView photonView;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            photonView.RPC("ChangeColor", RpcTarget.Others);
        }
    }

    [PunRPC]
    public void ChangeColor()
    {
        cubeRenderer.material = blue;
    }
}
