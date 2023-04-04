using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePool : MonoBehaviour
{
    [SerializeField] private RoleSprites[] roles;
    private static SpritePool pool;

    public static SpritePool Instance
    {
        get
        {
            return pool;
        }
    }
    
    void Awake()
    {
        if (pool != null && pool != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            pool = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public Sprite GetSpriteByRole(CharacterManager.Roles role)
    {
        for (int i = 0; i < roles.Length; i++)
        {
            if (role == roles[i].role) return roles[i]._sprite;
        }
        return null;
    }

}
