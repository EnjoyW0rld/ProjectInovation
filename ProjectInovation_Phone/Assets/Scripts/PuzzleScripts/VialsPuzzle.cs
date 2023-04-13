using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VialsPuzzle : MonoBehaviour
{
    [SerializeField, Tooltip("0 - green, 1 - triangle,2 - square, 3 - tall")] private Sprite[] sprites = new Sprite[4];
    [SerializeField] private Image[] vials;
    [SerializeField] private int[] sequence;
    [SerializeField] private int[] currentPlacement;
    private ClickHandler[] clickObjects;

    [SerializeField] private int chosenImage = -1;

    private void Start()
    {
        clickObjects = new ClickHandler[vials.Length];
        for (int i = 0; i < vials.Length; i++)
        {
            clickObjects[i] = vials[i].gameObject.AddComponent<ClickHandler>();
            clickObjects[i].OnPointerClicked.AddListener(OnObjectClick);
            clickObjects[i].SetObjID(i);
        }
        //currentPlacement = new int[vials.Length];
        /*
        for (int i = 0; i < currentPlacement.Length; i++)
        {
            currentPlacement[i] = i;
        }
         */

        SetImages();
    }

    private void OnObjectClick(int id)
    {
        if (chosenImage == -1)
        {
            chosenImage = id;
        }
        else
        {

            int previousId = GetIdOf(id); //place in array of id
            int idToChange = GetIdOf(chosenImage); //place in array of prev id
            currentPlacement[previousId] = chosenImage;
            currentPlacement[idToChange] = id;

            //print(chosenImage);
            //print(id);

            SwitchPlaces(id);
            //int previousPlace = currentPlacement[id];

            //currentPlacement[id] = chosenImage;
            //currentPlacement[chosenImage] = previousPlace;
            chosenImage = -1;
        }
        //SetImages();
    }
    private void SetImages()
    {
        for (int i = 0; i < vials.Length; i++)
        {
            vials[i].sprite = sprites[currentPlacement[i]];
        }
    }
    private void SwitchPlaces(int id)
    {
        Vector3 previousPos = vials[id].rectTransform.position;
        vials[id].rectTransform.position = vials[chosenImage].rectTransform.position;
        vials[chosenImage].rectTransform.position = previousPos;
    }
    private int GetIdOf(int num)
    {
        for (int i = 0; i < currentPlacement.Length; i++)
        {
            if (currentPlacement[i] == num) return i;
        }
        return -1;
    }
}