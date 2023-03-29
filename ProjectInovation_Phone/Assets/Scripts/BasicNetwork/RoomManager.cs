using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI roomName;
    // Start is called before the first frame update
    void Start()
    {
        roomName.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
    }

}
