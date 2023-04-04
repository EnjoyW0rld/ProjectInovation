using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoleSprites")]
public class RoleSprites : ScriptableObject
{
    public CharacterManager.Roles role;

    public Sprite _sprite;
}
