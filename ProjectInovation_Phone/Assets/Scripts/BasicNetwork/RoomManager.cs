using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI roomName;
    [SerializeField] private CharacterContainer[] _characters;

    [SerializeField] private GameObject selectionScreen;
    [SerializeField] private GameObject readyScreen;
    private PlayerData myView;


    void Start()
    {
        myView = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity).GetComponent<PlayerData>();
        //myView.GetComponent<PlayerData>().SetId(PhotonNetwork.CurrentRoom.PlayerCount - 1);// = PhotonNetwork.ViewCount + 1;
        myView.Initialize(PhotonNetwork.CurrentRoom.PlayerCount - 1, myView.GetComponent<PhotonView>());
        UserPrivateData.Instance.Initialize(myView.ID);

        roomName.text = "CODE: " + PhotonNetwork.CurrentRoom.Name;
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

        readyScreen.SetActive(true);
        myView.View.RPC("UpdateSprite", RpcTarget.All, myView.ID, (int)myView.GetRole());
        //readyScreen.GetComponent<ReadyHandler>().SetImage(myView.ID, myView.GetSprite());
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(myView.ChoseRole())
        myView.View.RPC("UpdateSprite", RpcTarget.All, myView.ID, (int)myView.GetRole());

        base.OnPlayerEnteredRoom(newPlayer);
    }

    //Get functions
    public int GetID() => myView.GetComponent<PlayerData>().ID;
    public PlayerData GetPlayerData() => myView;
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("GameScreen");
    }

}

class CharacterContainer
{
    public Image _character;
    public int id = -1;
    public CharacterManager.Roles role;
}
