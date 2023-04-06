using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsHint : MonoBehaviour
{
    [SerializeField] private GameObject[] lights = new GameObject[3];
    [SerializeField] private int[] sequnce = new int[3];
    [SerializeField] private float TimeBetweenSequence = 3;
    private float timeLeft;
    //private float currentPlace;

    private void Start()
    {
        timeLeft = TimeBetweenSequence;
    }

    void Update()
    {
        if(timeLeft < 0)
        {
            timeLeft = 0;
            print("starting coroutine");
            StartCoroutine("SwitchLights");
        }else if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
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
    }
}
