using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private Image image;
    [HideInInspector] public UnityEvent OnReadyChanged;
    //[SerializeField] private Button button;
    private TVLight lights;
    private bool isReady;

    private void Start()
    {
        lights = GetComponentInChildren<TVLight>(true);
        //button.onClick.AddListener(OnButtonPressed);
    }

    public void SetImage(Sprite spr) => image.sprite = spr;

    [ContextMenu("FindVariables")]
    private void FindImageAndButton()
    {
        image = GetComponentInChildren<Image>(true);
        //button = GetComponentInChildren<Button>(true);
    }

    public void ChangeReady()
    {
        isReady = !isReady;
        if (isReady) lights.SetImage(0);
        else lights.SetImage(2);

        OnReadyChanged?.Invoke();
    }
    public bool IsReady { get { return isReady; } }

}
