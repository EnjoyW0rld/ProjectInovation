using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleGameTimer : MonoBehaviour
{
    [SerializeField] private float gameTime;
    [SerializeField] private TextMeshProUGUI text;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = RoundToTwo(timeLeft) + "";
    }
    private float RoundToTwo(float val)
    {
        return ((int)(val * 100)) / 100.0f;
    }

}
