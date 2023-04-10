using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglePuzzle : MonoBehaviour
{
    public GameObject[] toggles;
    public Sprite[] togglesSprites;
    public int[] currentPositions;
    public int[] solvePositions;

    private bool allChecked = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < currentPositions.Length; i++)
        {
            ChangeSprite(toggles[i], currentPositions[i]);
        }
    }

    // Update is called once per frame
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

    public void ChangeSprite (GameObject gameObj, int currentPos)
    {
        gameObj.GetComponent<SpriteRenderer>().sprite = togglesSprites[currentPos];
    }

    private bool isClicked(GameObject checkObject)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == checkObject)
            {
                AudioSource audioSource = checkObject.GetComponent<AudioSource>();
                audioSource.Play();
                return true;
            }
        }
        return false;
    }
}
