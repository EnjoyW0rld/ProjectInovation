using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class preserveToggleSequence : MonoBehaviour
{
    [SerializeField]
    private Sprite[] ovenButtons_Sprites;
    [SerializeField]
    private Image[] buttons;

    public togglePuzzle TogglePuzzleScript;
    private int[] solveArray;

    // Start is called before the first frame update
    void Start()
    {
        solveArray = TogglePuzzleScript.solvePositions;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < solveArray.Length; i++)
        {
            change_Oven_Sprite(buttons[i],solveArray[i]);
        }
    }

    private void change_Oven_Sprite(Image gameObj, int currentPos)
    {
        gameObj.sprite = ovenButtons_Sprites[currentPos];
    }
}
