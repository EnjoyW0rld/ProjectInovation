using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVLight : MonoBehaviour
{
    [SerializeField] private Sprite[] lights;
    [SerializeField] private Image image;

    [ContextMenu("FindImage")]
    private void FindImage()
    {
        image = GetComponent<Image>();
    }

    public void SetImage(int light)
    {
        image.sprite = lights[light];
    }
    

}
