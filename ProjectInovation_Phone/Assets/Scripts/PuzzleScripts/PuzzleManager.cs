using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuzzleManager : MonoBehaviour
{
    //private PlayerData playerData;
    private PhotonView view;
    [SerializeField] private Transform canvas;
    [SerializeField] private PuzzleRoom[] rooms;
    [SerializeField] private GameObject lobbyRoomPrefab;
    [SerializeField] private GameObject monsterAttack;
    //Debug variables
    [SerializeField] private CharacterManager.Roles roleToShow;
    [SerializeField] private bool isDebug;

    [SerializeField] private float timeBetweenAttacks = 15;
    private float timeTillMonsterAttack;
    private int puzzlesDone;

    private void Awake()
    {
        view = PhotonNetwork.Instantiate("PlayerForPuzzle", Vector3.zero, Quaternion.identity).GetComponent<PhotonView>();
    }
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            timeTillMonsterAttack = timeBetweenAttacks;
        }
        //REMOVE AFTER, ONLY FOR DEBUG OF LOBBY
        /**
        Instantiate(lobbyRoomPrefab, canvas);
        return;
        /**/
        //-----

        for (int i = 0; i < rooms.Length; i++)
        {
            if (isDebug)
            {
                if (rooms[i].GetOwner() == roleToShow)
                {
                    Instantiate(rooms[i], canvas);
                }
            }
            else
            {
                if (rooms[i].GetOwner() == UserPrivateData.Instance.GetRole())
                {
                    Instantiate(rooms[i], canvas);
                }
            }
        }
    }
    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (timeTillMonsterAttack <= 0)
            {
                //int id = Random.Range(0, 1);
                print("time for monster");
                if (isDebug)
                {
                    SpawnMonster();
                    timeTillMonsterAttack = timeBetweenAttacks;
                }
                else
                {
                    view.RPC("MonsterAttack", RpcTarget.All, 0);
                    timeTillMonsterAttack = timeBetweenAttacks;
                }
            }
            else
            {
                timeTillMonsterAttack -= Time.deltaTime;
            }
        }
    }

    public void SpawnMonster()
    {
        MonsterSteady attack = Instantiate(monsterAttack, canvas).GetComponent<MonsterSteady>();
        attack.OnFailed.AddListener(FailedMonsterAttack);
    }



    public void BroadcastFinish(bool won)
    {
        view.RPC("GameFinish",RpcTarget.All, won);
    }
    //Set win state in singleton and change scene
    public void FinishTheGame(bool won)
    {
        UserPrivateData.Instance.SetWonState(won);
        if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel("EndScreen");
    }
    //IMplement monster fail behaviour here
    private void FailedMonsterAttack()
    {

    }
    public void OnPuzzleDone()
    {
        view.RPC("DonePuzzle", RpcTarget.MasterClient, UserPrivateData.Instance.GetInstanceID());
    }

    public void PuzzleCompleteHandler(int id)
    {
        print("Done puzzle");
        puzzlesDone++;
        if (PhotonNetwork.IsMasterClient)
        {
            if (puzzlesDone == 4)
            {
                view.RPC("ChangeToLobby", RpcTarget.All);
                //PhotonNetwork.LoadLevel("Menu");
            }
        }
    }
}
