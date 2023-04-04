using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Button button;

    public void Deselect()
    {
        button.gameObject.SetActive(false);
    }
    public void SetImage(Sprite spr) => image.sprite = spr;

    [ContextMenu("FindVariables")]
    private void FindImageAndButton()
    {
        image = GetComponentInChildren<Image>(true);
        button = GetComponentInChildren<Button>(true);
    }

}
