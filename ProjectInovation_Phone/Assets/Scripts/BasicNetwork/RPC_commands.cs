using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class RPC_commands : MonoBehaviour
{
    //[HideInInspector] public UnityEvent<int, Sprite, bool> OnReadyChange;


    private ReadyHandler readyHandler;
    private RoomManager roomManager;

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
    private void UpdateOccupied(int role)
    {
        if (roomManager == null) roomManager = FindObjectOfType<RoomManager>();
        roomManager.OccupyRole(role);
    }

    [PunRPC]
    private void Ping(string text)
    {
        Debug.Log(text);
    }

    //Commands for puzzle games
    //------------------------------------------
    
    PuzzleManager puzzleManager;

    [PunRPC]
    private void MonsterAttack(int ID)
    {
        print("is called!!!");
        if (puzzleManager == null) puzzleManager = FindObjectOfType<PuzzleManager>();
        if (UserPrivateData.Instance.GetID() == ID)
        {
            print("Spawn monster");
            puzzleManager.SpawnMonster();
        }
        //print(UserPrivateData.Instance.GetID() + " current id");

    }
    [PunRPC]
    private void DonePuzzle(int id)
    {
        if (puzzleManager == null) puzzleManager = FindObjectOfType<PuzzleManager>();
        
        puzzleManager.PuzzleCompleteHandler(id);
    }
    [PunRPC]
    private void ChangeToLobby()
    {
        if (puzzleManager == null) puzzleManager = FindObjectOfType<PuzzleManager>();
        puzzleManager.ChangeToLobby();
    }
    [PunRPC]
    private void GameFinish(bool won)
    {
        if (puzzleManager == null) puzzleManager = FindObjectOfType<PuzzleManager>();
        puzzleManager.FinishTheGame(won);
    }

}
