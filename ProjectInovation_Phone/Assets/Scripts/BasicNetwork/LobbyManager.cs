using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Text;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public void OnHostPressed()
    {
        PhotonNetwork.CreateRoom(GenerateRandomString());
    }

    public void OnConnectPressed(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }
    public override void OnJoinedRoom()
    {
            //PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        PhotonNetwork.LoadLevel("LobbyRoom");
    }

    public static string GenerateRandomString()
    {
        StringBuilder sb = new StringBuilder();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        for (int i = 0; i < 5; i++)
        {
            sb.Append(chars[Random.Range(0, chars.Length)]);
        }
        return sb.ToString();

    }
}
