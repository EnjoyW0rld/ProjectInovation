using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineReplacer : MonoBehaviour
{
    [SerializeField] private PlayableAsset second;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private float waitTime;
    //public bool setSecond;
    //private bool executed;
    public void SetSecond()
    {
        //executed = true;
        director.playableAsset = second;
        director.Play();
        print("Starting cfsodfods");
        StartCoroutine(WaitBeforeVideo());
    }
    IEnumerator WaitBeforeVideo()
    {
        
        yield return new WaitForSeconds(waitTime);
        print("startplayplay");
        director.Stop();
        FindObjectOfType<MyVideoPlayer>().Play();
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
