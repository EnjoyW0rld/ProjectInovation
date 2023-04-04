using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    private Image image;
    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponentInChildren<Image>();
        button = GetComponentInChildren<Button>(true);
    }
    public void Deselect()
    {
        button.gameObject.SetActive(false);
    }
    public void SetImage(Sprite spr) => image.sprite = spr;
}
