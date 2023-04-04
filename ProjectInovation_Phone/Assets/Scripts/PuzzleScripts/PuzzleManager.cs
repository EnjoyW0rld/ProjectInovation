using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuzzleManager : MonoBehaviour
{
    private PlayerData playerData;

    void Awake()
    {
        PhotonNetwork.Instantiate("PlayerForPuzzle", Vector3.zero, Quaternion.identity);
        Debug.Log(UserPrivateData.Instance.GetRole());
    }
    private void Start()
    {
        Debug.Log(playerData.GetRole());
    }
    
}
