using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneVibration : MonoBehaviour
{
    [SerializeField] private TMP_InputField field;
    public void Vibrate()
    {
        Vibration.Vibrate(int.Parse(field.text));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Handheld.Vibrate();
        }  
    }
}
