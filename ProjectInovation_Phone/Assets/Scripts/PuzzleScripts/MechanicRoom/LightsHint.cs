using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsHint : TaskGeneral
{
    [SerializeField] private GameObject[] lights = new GameObject[3];
    [SerializeField] private int[] sequnce = new int[3];
    [SerializeField] private float TimeBetweenSequence = 3;
    [SerializeField] private bool trigger=false;
    [SerializeField] private AudioSource[] blink;
    private int no = 0;
    private float timeLeft;
    //private float currentPlace;

    private void Start()
    {
        timeLeft = -1;// TimeBetweenSequence;
    }

    void Update()
    {
        if (trigger)
        {
            if (timeLeft < 0)
            {
                timeLeft = 0;
                print("starting coroutine");
                StartCoroutine("SwitchLights");
            }
            else if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
        }
    }

    private IEnumerator SwitchLights()
    {
        for (int i = 0; i < sequnce.Length; i++)
        {
            TurnLight(sequnce[i]);
            yield return new WaitForSeconds(1);
        }
        TurnLight(-1);
        timeLeft = TimeBetweenSequence;
    }

    private void TurnLight(int lightID)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(i == lightID);
        }
        blink[no].Play();
        Debug.Log(no);
        if (no < blink.Length-1)
        {
            no++;
        }
        else no = 0;

    }
    
    public void buttonActivated()
    {
        trigger = true;
    }

}
