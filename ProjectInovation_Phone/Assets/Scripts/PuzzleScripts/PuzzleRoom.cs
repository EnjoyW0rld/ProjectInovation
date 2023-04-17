using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuzzleRoom : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private CharacterManager.Roles role;
    public UnityEvent OnComplete;

    public CharacterManager.Roles GetOwner() => role;
}
