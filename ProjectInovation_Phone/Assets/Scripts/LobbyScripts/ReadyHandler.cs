using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ReadyHandler : MonoBehaviour
{
    [SerializeField] private PlayerCard[] cards = new PlayerCard[4];
    private int id;
    private RoomManager roomManager;


    void Start()
    {
        roomManager = FindObjectOfType<RoomManager>();
        id = roomManager.GetID();
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].OnReadyChanged.AddListener(OnReadyChanged);
        }
    }

    public void SetImage(int id, Sprite image)
    {
        Animator animator = cards[id].transform.GetChild(1).GetComponent<Animator>();
        animator.enabled = false;

        print("Changing sprite for" + id);
        cards[id].SetImage(image);
    }
    public void OnReadyPressed()
    {
        roomManager.GetPlayerData().View.RPC("UpdateReady", RpcTarget.All, roomManager.GetID());
    }
    public void UpdateReady(int id)
    {
        cards[id].ChangeReady();
    }
    private void OnReadyChanged()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        for (int i = 0; i < cards.Length; i++)
        {
            if (!cards[i].IsReady) return;
        }
        PhotonNetwork.LoadLevel("GameScreen");

    }

}
