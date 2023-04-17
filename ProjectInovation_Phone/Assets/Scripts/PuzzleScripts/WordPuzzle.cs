using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class WordPuzzle : TaskGeneral
{
    [SerializeField, Tooltip("Not case sensitive")] private string targetWord;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button inputButton;
    public UnityEvent OnFail;

    private void Start()
    {
        inputButton.onClick.AddListener(OnButtonPress);
        targetWord = targetWord.ToLower();
    }
    private void OnButtonPress()
    {
        if (inputField.text.ToLower() == targetWord)
        {
            OnComplete?.Invoke();
        }
        else
        {
            OnFail?.Invoke();
        }
    }
    public void BackToMenu()
    {
        FindObjectOfType<PuzzleManager>().BroadcastFinish(true);
        //Photon.Pun.PhotonNetwork.LoadLevel("Menu");
    }

}
