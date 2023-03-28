using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectToCloud : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputButtonHandler connectButton;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        connectButton.OnButtonPressed.AddListener(OnConnectClicked);
    }

    private void OnConnectClicked(string text)
    {
        PhotonNetwork.JoinRoom(text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Debug.Log(roomList[i].Name);
        }
    }
}
