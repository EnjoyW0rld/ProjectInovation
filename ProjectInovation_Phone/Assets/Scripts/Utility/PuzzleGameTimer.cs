using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleGameTimer : MonoBehaviour
{
    [SerializeField] private float gameTime;
    [SerializeField] private TextMeshProUGUI text;
    private float timeLeft;

    void Start()
    {
        PuzzleGameTimer[] timer = FindObjectsOfType<PuzzleGameTimer>();

        if (timer.Length == 1)
        {
            timeLeft = gameTime;
        }
        else
        {
            for (int i = 0; i < timer.Length; i++)
            {
                if (timer[i] != this)
                {
                    print("removed timer");
                    timeLeft = timer[i].GetTimeLeft();
                    Destroy(timer[i].gameObject);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //text.text = RoundToTwo(timeLeft / 60f).ToString() + "";
        string str = RoundToTwo(timeLeft / 60f).ToString() + "";

        text.text = str.Replace('.', ':');
        //text.text = GetAsText(timeLeft / 60f);
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            if (Photon.Pun.PhotonNetwork.IsMasterClient)
                FindObjectOfType<PuzzleManager>().BroadcastFinish(false);
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }
    private float RoundToTwo(float val)
    {
        return ((int)(val * 100)) / 100.0f;

    }
    public float GetTimeLeft() => timeLeft;

}
