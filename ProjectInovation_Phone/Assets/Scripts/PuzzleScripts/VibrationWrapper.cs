using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationWrapper : MonoBehaviour
{
    [SerializeField, Tooltip("Use '.' and '-' only")] private string sequnce;
    // Start is called before the first frame update
    [SerializeField] private long shortLength = 400;
    [SerializeField] private long longLength = 1000;
    [SerializeField] private float breakBetween = .2f;

    private bool coroutinePlaying;

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

        for (int i = 0; i < sequnce.Length; i++)
        {
            float playTime = sequnce[i] == '.' ? shortLength : longLength;
            Vibration.Vibrate((long)playTime);
            yield return new WaitForSeconds(breakBetween + (playTime / 1000));
        }
        coroutinePlaying = false;
    }
}
