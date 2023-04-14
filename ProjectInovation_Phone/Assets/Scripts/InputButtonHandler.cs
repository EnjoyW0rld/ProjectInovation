using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class InputButtonHandler : MonoBehaviour
{
    private string text;
    private Button button;
    [SerializeField] private TMP_InputField inputField;

    public UnityEvent<string> OnButtonPressed;

    void Start()
    {
        button = GetComponent<Button>();
        inputField.onValueChanged.AddListener(OnInputChange);
        button.onClick.AddListener(PressedButton);
    }

    private void PressedButton()
    {
        OnButtonPressed?.Invoke(text.ToUpper());
    }

    private void OnInputChange(string text)
    {
        this.text = text;
    }
}
