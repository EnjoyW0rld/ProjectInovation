using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPrivateData : MonoBehaviour
{
    private static UserPrivateData data;
    public static UserPrivateData Instance { get { return data; } }

    private CharacterManager.Roles playerRole;
    private int id = -1;
    private bool wonTheGame;

    void Awake()
    {
        if (data != null && data != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            data = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetWonState(bool won) => wonTheGame = won;
    public void SetRole(CharacterManager.Roles role)
    {
        playerRole = role;
    }
    public CharacterManager.Roles GetRole() => playerRole;

    public int GetID() => id;
    public bool GetWonState() => wonTheGame;

    public void Initialize(int id)
    {
        this.id = id;
    }

}
