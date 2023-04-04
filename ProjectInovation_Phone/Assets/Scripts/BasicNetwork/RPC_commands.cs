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
        if (readyHandler == null) readyHandler = FindObjectOfType<ReadyHandler>();
        readyHandler.SetImage(ID, SpritePool.Instance.GetSpriteByRole((CharacterManager.Roles)role));
        //OnReadyChange?.Invoke(ID, SpritePool.Instance.GetSpriteByRole((CharacterManager.Roles)role), false);
        print("Invoked");
    }
}
