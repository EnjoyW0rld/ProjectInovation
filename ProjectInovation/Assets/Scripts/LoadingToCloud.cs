using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LoadingToCloud : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputButtonHandler hostButton;
    [SerializeField] private GameObject playerPrefab;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        hostButton.OnButtonPressed.AddListener(OnHostPressed);
    }
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
        Debug.Log("joined lobby");
    }
    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
    }

    private void OnHostPressed(string name)
    {
        PhotonNetwork.CreateRoom(name);
        Debug.Log("room created");
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("Player joined room");
        //PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }
}
