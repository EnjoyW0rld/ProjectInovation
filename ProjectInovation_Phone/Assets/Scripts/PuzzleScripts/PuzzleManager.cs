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
    private GameObject currentRoom;

    //Debug variables
    [SerializeField] private CharacterManager.Roles roleToShow;
    [SerializeField] private bool isDebug;

    [SerializeField] private float timeBetweenAttacks = 15;
    private float timeTillMonsterAttack;
    private int puzzlesDone;
    private List<int> completeIDs = new List<int>();
    private bool isGameFinished;

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
                    currentRoom = Instantiate(rooms[i], canvas).gameObject;
                }
            }
            else
            {
                if (rooms[i].GetOwner() == UserPrivateData.Instance.GetRole())
                {
                    currentRoom = Instantiate(rooms[i], canvas).gameObject;
                    currentRoom.transform.SetSiblingIndex(0);
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
                    print("this person id " + UserPrivateData.Instance.GetID());
                    view.RPC("MonsterAttack", RpcTarget.All, 0);
                    timeTillMonsterAttack = timeBetweenAttacks;
                }
            }
            else
            {
                timeTillMonsterAttack -= Time.deltaTime;
            }
        }

        //DEBUG SETTING REMOVE
        if (Input.GetKeyDown(KeyCode.N))
        {
            ChangeToLobby();
        }
    }

    public void SpawnMonster()
    {
        MonsterSteady attack = Instantiate(monsterAttack, canvas).GetComponent<MonsterSteady>();
        attack.OnFailed.AddListener(FailedMonsterAttack);
    }
    /// <summary>
    /// When you want to finish the game call this method
    /// </summary>
    /// <param name="won"></param>
    public void BroadcastFinish(bool won)
    {
        view.RPC("GameFinish", RpcTarget.All, won);
    }
    //Set win state in singleton and change scene
    public void FinishTheGame(bool won)
    {
        UserPrivateData.Instance.SetWonState(won);
        if (PhotonNetwork.IsMasterClient && !isGameFinished)
        {
            isGameFinished = true;
            PhotonNetwork.LoadLevel("EndScreen");
        }
    }
    //IMplement monster fail behaviour here
    private void FailedMonsterAttack()
    {

    }
    public void OnPuzzleDone()
    {
        view.RPC("DonePuzzle", RpcTarget.MasterClient, UserPrivateData.Instance.GetID());
    }

    public void PuzzleCompleteHandler(int id)
    {
        if (completeIDs.Contains(id)) return;
        puzzlesDone++;
        completeIDs.Add(id);
        if (PhotonNetwork.IsMasterClient)
        {
            print("current puzzle count " + puzzlesDone);
            if (puzzlesDone == 2)
            {
                view.RPC("ChangeToLobby", RpcTarget.All);
                //PhotonNetwork.LoadLevel("Menu");
            }
        }
    }
    //Set everyone room to lobby
    public void ChangeToLobby()
    {
        currentRoom.SetActive(false);
        Instantiate(lobbyRoomPrefab, canvas);
    }
}