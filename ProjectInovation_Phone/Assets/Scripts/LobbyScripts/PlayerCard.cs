using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    private TVLight lights;
    bool isReady;

    private void Start()
    {
        lights = GetComponentInChildren<TVLight>(true);
        //button.onClick.AddListener(OnButtonPressed);
    }

    /**
    public void Deselect()
    {
        button.gameObject.SetActive(false);
    }
    /**/
    public void SetImage(Sprite spr) => image.sprite = spr;

    [ContextMenu("FindVariables")]
    private void FindImageAndButton()
    {
        image = GetComponentInChildren<Image>(true);
        button = GetComponentInChildren<Button>(true);
    }
    public void ChangeReady()
    {
        isReady = !isReady;
        if (isReady) lights.SetImage(0);
        else lights.SetImage(2);
    }

}
