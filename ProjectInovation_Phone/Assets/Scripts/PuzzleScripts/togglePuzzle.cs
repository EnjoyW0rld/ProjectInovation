using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class togglePuzzle : TaskGeneral
{
    public Image[] toggles;
    public Sprite[] togglesSprites;
    public int[] currentPositions;
    public int[] solvePositions;

    private bool allChecked = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < currentPositions.Length; i++)
        {
            ClickHandler handler = toggles[i].gameObject.AddComponent<ClickHandler>();
            handler.OnPointerClicked.AddListener(ClickedOnButton);
            handler.SetObjID(i);
            ChangeSprite(toggles[i], currentPositions[i]);
        }
    }

    // Update is called once per frame
        /**
    void Update()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (isClicked(toggles[i]))
            {
                if (currentPositions[i] <= 2)
                {
                    currentPositions[i]++;
                }
                else
                {
                    currentPositions[i] = 0;
                }
                ChangeSprite(toggles[i], currentPositions[i]);
            }
        }

        if (allChecked == false)
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if (currentPositions[i] != solvePositions[i])
                {
                    allChecked = false;
                    break;
                }
                allChecked = true;
            }
            if(allChecked)
            {
                //Execute some code
                Debug.Log("Puzzle solved!");
                GetComponent<AudioSource>().Play();
            }
        }
    }
        /**/

    public void ChangeSprite (Image gameObj, int currentPos)
    {
        gameObj.sprite = togglesSprites[currentPos];
        //gameObj.GetComponent<SpriteRenderer>().sprite = togglesSprites[currentPos];
    }

    private void ClickedOnButton(int id)
    {
        isClicked(toggles[id]);
        if (currentPositions[id] <= 2)
        {
            currentPositions[id]++;
        }
        else
        {
            currentPositions[id] = 0;
        }

        ChangeSprite(toggles[id], currentPositions[id]);

        if (allChecked == false)
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if (currentPositions[i] != solvePositions[i])
                {
                    allChecked = false;
                    break;
                }
                allChecked = true;
            }
            if (allChecked)
            {
                //Execute some code
                Debug.Log("Puzzle solved!");
                OnComplete?.Invoke();
                GetComponent<AudioSource>().Play();
            }
        }

    }

    private void isClicked(Image checkObject)
    { 
                AudioSource audioSource = checkObject.GetComponent<AudioSource>();
                audioSource.Play();
             //   return true;
       // return false;
    }
}
