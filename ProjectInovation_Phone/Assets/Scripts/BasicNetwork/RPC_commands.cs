using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class RPC_commands : MonoBehaviour
{
    //[HideInInspector] public UnityEvent<int, Sprite, bool> OnReadyChange;


    private ReadyHandler readyHandler;

    [PunRPC]
    private void UpdateSprite(int ID, int role)
    {
        if (readyHandler == null) readyHandler = FindObjectOfType<ReadyHandler>(true);
        print(SpritePool.Instance.GetSpriteByRole((CharacterManager.Roles)role));
        readyHandler.SetImage(ID, SpritePool.Instance.GetSpriteByRole((CharacterManager.Roles)role));
    }
    [PunRPC]
    private void UpdateReady(int ID)
    {
        if (readyHandler == null) readyHandler = FindObjectOfType<ReadyHandler>(true);
        readyHandler.UpdateReady(ID);
        print(ID);
    }

    [PunRPC]
    private void Ping(string text)
    {
        Debug.Log(text);
    }

    PuzzleManager puzzleManager;

    [PunRPC]
    private void MonsterAttack(int ID)
    {
        if (puzzleManager == null) puzzleManager = FindObjectOfType<PuzzleManager>();
        if (UserPrivateData.Instance.GetInstanceID() == ID) puzzleManager.SpawnMonster();
        //print(UserPrivateData.Instance.GetID() + " current id");

    }
    [PunRPC]
    private void DonePuzzle(int id)
    {
        if (puzzleManager == null) puzzleManager = FindObjectOfType<PuzzleManager>();
        puzzleManager.PuzzleCompleteHandler(id);
    }
}
