using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    const int CHARACTER_COUNT = 1;
    public enum Roles { Engineer = 0, Chemist = 1, Analyst = 2, Mechanic = 3 }
    [SerializeField] private RoleSprites[] _characterSprites;// = new RoleSprites[CHARACTER_COUNT];
    [SerializeField] private Image image;
    private Roles role;
    [HideInInspector] public UnityEvent<RoleSprites> OnSelected;

    void Start()
    {
        _characterSprites = SpritePool.Instance.GetAllRoles();
        role = 0;
    }

    public void ScrollNext()
    {
        if ((int)role == _characterSprites.Length - 1) role = 0;
        else role++;
        UpdateSprite();
    }
    public void ScrollBack()
    {
        if ((int)role == 0) role = (Roles)_characterSprites.Length - 1;
        else role--;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        for (int i = 0; i < _characterSprites.Length; i++)
        {
            if (_characterSprites[i].role == role)
            {
                image.sprite = _characterSprites[i]._sprite;
                break;
            }
        }
    }

    public void Select()
    {
        for (int i = 0; i < _characterSprites.Length; i++)
        {
            if (role == _characterSprites[i].role)
            {
                UserPrivateData.Instance.SetRole(role);
                OnSelected?.Invoke(_characterSprites[i]);
                break;
            }

        }
    }

    private void OnValidate()
    {

        if (_characterSprites.Length > CHARACTER_COUNT + 1)
        {
            RoleSprites[] sp = new RoleSprites[CHARACTER_COUNT + 1];
            for (int i = 0; i < sp.Length; i++)
            {
                sp[i] = _characterSprites[i];
            }
            _characterSprites = sp;
        }
    }

    public Sprite GetSpriteByRole(Roles role)
    {
        for (int i = 0; i < _characterSprites.Length; i++)
        {
            if(role == _characterSprites[i].role) return _characterSprites[i]._sprite;
        }
        return null;
    }
}