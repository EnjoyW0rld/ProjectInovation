using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI[] roomName;
    [SerializeField] private CharacterContainer[] _characters;

    [SerializeField] private GameObject selectionScreen;
    [SerializeField] private GameObject readyScreen;
    private PlayerData myView;

    private List<CharacterManager.Roles> takenRoles = new List<CharacterManager.Roles>();
    /*
    private void Awake()
    {
        freeRoles = new List<CharacterManager.Roles>() { 
            CharacterManager.Roles.Engineer,
            CharacterManager.Roles.Analyst,
            CharacterManager.Roles.Chemist,
            CharacterManager.Roles.Mechanic
        };
    }
     */

    void Start()
    {
        myView = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity).GetComponent<PlayerData>();
        myView.Initialize(PhotonNetwork.CurrentRoom.PlayerCount - 1, myView.GetComponent<PhotonView>());
        UserPrivateData.Instance.Initialize(myView.ID);

        for (int i = 0; i < roomName.Length; i++)
        {
            roomName[i].text = "CODE: " + PhotonNetwork.CurrentRoom.Name;
        }
        selectionScreen.GetComponent<CharacterManager>().OnSelected.AddListener(OnCharacterSelected);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("GameScreen");
        //myView.View.RPC("UpdateCharacter", RpcTarget.All,1);

    }
    private void OnCharacterSelected(RoleSprites role)
    {
        myView.SetRole(role);
        selectionScreen.SetActive(false);

        myView.View.RPC("UpdateOccupied", RpcTarget.All, (int)role.role); //Occupy role

        readyScreen.SetActive(true);
        myView.View.RPC("UpdateSprite", RpcTarget.All, myView.ID, (int)myView.GetRole());
        //readyScreen.GetComponent<ReadyHandler>().SetImage(myView.ID, myView.GetSprite());
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (myView.ChoseRole())
            myView.View.RPC("UpdateSprite", RpcTarget.All, myView.ID, (int)myView.GetRole());

        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < takenRoles.Count; i++)
            {
                myView.View.RPC("UpdateOccupied", newPlayer, (int)takenRoles[i]);
            }
        }

        base.OnPlayerEnteredRoom(newPlayer);
    }

    public void OccupyRole(int role)
    {
        takenRoles.Add((CharacterManager.Roles)role);
        print("RoleOccupied " + (CharacterManager.Roles)role);
    }
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("GameScreen");
    }
    //Get functions
    public bool isRoleTaken(CharacterManager.Roles role)
    {
        return takenRoles.Contains(role);

    }
    public bool isRoleTaken(int role)
    {
        return takenRoles.Contains((CharacterManager.Roles)role);
    }
    public int GetID() => myView.GetComponent<PlayerData>().ID;
    public PlayerData GetPlayerData() => myView;

}

class CharacterContainer
{
    public Image _character;
    public int id = -1;
    public CharacterManager.Roles role;
}
