using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineReplacer : MonoBehaviour
{
    [SerializeField] private PlayableAsset second;
    [SerializeField] private PlayableDirector director;

    //public bool setSecond;
    //private bool executed;
    public void SetSecond()
    {
        //executed = true;
        director.playableAsset = second;
    }
    /*
    private void Update()
    {
        if (setSecond && !executed)
        {
            SetSecond();
        }
    }
     */
}
