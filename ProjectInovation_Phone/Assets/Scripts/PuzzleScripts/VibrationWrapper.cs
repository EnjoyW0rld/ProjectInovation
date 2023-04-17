using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationWrapper : MonoBehaviour
{
    [SerializeField, Tooltip("Use '.' and '-' only")] private string sequnce;
    [SerializeField] private Animator animator;

    [SerializeField] private long shortLength;// = 400;
    [SerializeField] private long longLength;// = 1000;
    [SerializeField] private float breakBetweenVibrations;// = .2f;
    [SerializeField] private float breakBetweenNumbers;// = 3f;

    private bool coroutinePlaying;

    private void Start()
    {
        print(shortLength);
        print(longLength);
        if (animator == null)
        {
            animator = FindObjectOfType<Animator>(true);
        }//print("animtor is null in start!");
        //Play();
    }
    private void Update()
    {
        Play();
        //if (Input.GetKeyDown(KeyCode.V)) Play();
    }


    public void Play()
    {
        if (!coroutinePlaying)
        {
            coroutinePlaying = true;
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        print("play starts again");
        for (int i = 0; i < sequnce.Length; i++)
        {
            if (sequnce[i] == ' ')
            {
                yield return new WaitForSeconds(breakBetweenNumbers);
                continue;
            }

            float playTime = sequnce[i] == '.' ? shortLength : longLength;
            print("playing length " + playTime);
            Vibration.Vibrate((long)playTime);
            StartCoroutine(PlayAnimation(playTime / 1000f));
            print("starting break for " + breakBetweenVibrations + (playTime / 1000));
            yield return new WaitForSeconds(breakBetweenVibrations + (playTime / 1000));
        }
        yield return new WaitForSeconds(breakBetweenNumbers * 2);
        coroutinePlaying = false;
    }
    IEnumerator PlayAnimation(float time)
    {
        //if (animator == null) print("animator is null??");
        animator.Play("Moving");
        yield return new WaitForSeconds(time);
        animator.Play("Default");
    }
}
