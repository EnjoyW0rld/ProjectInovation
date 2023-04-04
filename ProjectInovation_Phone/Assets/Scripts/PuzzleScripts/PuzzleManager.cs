using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuzzleManager : MonoBehaviour
{
    private PlayerData playerData;
    private PhotonView view;



    void Awake()
    {
        view = PhotonNetwork.Instantiate("PlayerForPuzzle", Vector3.zero, Quaternion.identity).GetComponent<PhotonView>();
        Debug.Log(UserPrivateData.Instance.GetRole());
    }
    private void Start()
    {
        view.RPC("Ping", RpcTarget.All, "meme");
    }
    
}
