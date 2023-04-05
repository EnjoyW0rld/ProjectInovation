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
    

    void Awake()
    {
        //view = PhotonNetwork.Instantiate("PlayerForPuzzle", Vector3.zero, Quaternion.identity).GetComponent<PhotonView>();
        //Debug.Log(UserPrivateData.Instance.GetRole());
    }
    private void Start()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            Debug.Log("on room" + i);
            if(rooms[i].GetOwner() == CharacterManager.Roles.Engineer)
            {
                Instantiate(rooms[i], canvas);
                print("instantiatate");
            }
        }
        //view.RPC("Ping", RpcTarget.All, "meme");
    }
    
}
