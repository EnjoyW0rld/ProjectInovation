using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerData : MonoBehaviour
{
    //Player id variable
    private int id = -1;
    public int ID { get { return id; } }

    //Photon view variables
    private PhotonView view;
    public PhotonView View { get { return view; } }

    private RPC_commands commands;
    public RPC_commands Commands
    {
        get
        {
            if (commands == null) commands = GetComponent<RPC_commands>();
            return commands;
        }
    }

    public void Initialize(int id, PhotonView view)
    {
        this.id = id;
        this.view = view;
    }
    public void SetRole(RoleSprites role)
    {
        this.role = role;
    }

    public void SetId(int id) => this.id = id;

    //Role and sprite variables
    private RoleSprites role;
    public bool ChoseRole() => role != null;
    public Sprite GetSprite() => role._sprite;
    public CharacterManager.Roles GetRole() => role.role;
}
