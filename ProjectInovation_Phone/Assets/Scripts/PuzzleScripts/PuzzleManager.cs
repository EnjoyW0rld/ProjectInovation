using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuzzleManager : MonoBehaviour
{
    private PlayerData playerData;
    private PhotonView view;
    [SerializeField] private Transform canvas;
    [SerializeField] private PuzzleRoom[] rooms;

    [SerializeField] private CharacterManager.Roles roleToShow;
    void Awake()
    {
        //view = PhotonNetwork.Instantiate("PlayerForPuzzle", Vector3.zero, Quaternion.identity).GetComponent<PhotonView>();
        //Debug.Log(UserPrivateData.Instance.GetRole());
    }
    private void Start()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            if(rooms[i].GetOwner() == roleToShow)
            {
                Instantiate(rooms[i], canvas);
            }
        }
        //view.RPC("Ping", RpcTarget.All, "meme");
    }
    
}
