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
    [SerializeField] private GameObject monsterAttack;

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
                view.RPC("MonsterAttack", RpcTarget.All, 1);
                timeTillMonsterAttack = timeBetweenAttacks;
            }
            else
            {
                timeTillMonsterAttack -= Time.deltaTime;
            }
        }
    }

    public void SpawnMonster()
    {
        Instantiate(monsterAttack, canvas);
    }

    public void OnPuzzleDone()
    {
        view.RPC("DonePuzzle", RpcTarget.MasterClient, UserPrivateData.Instance.GetInstanceID());
    }

    public void PuzzleCompleteHandler(int id)
    {
        puzzlesDone++;
        if (PhotonNetwork.IsMasterClient)
        {
            if (puzzlesDone == 4)
            {
                PhotonNetwork.LoadLevel("Menu");
            }
        }
    }
}
