using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class MyVideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject playerTarget;

    [SerializeField] private UnityEvent OnVideoEnd;
    private bool invoked;
    public bool play;
    private bool started;


    public void Play()
    {
        playerTarget.SetActive(true);
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (play && !started)
        {
            started = true;
            Play();
        }

        if (!videoPlayer.isPlaying && videoPlayer.frame > 5)
        {
            if (!invoked)
            {
                OnVideoEnd?.Invoke();
                invoked = true;
            }
        }
    }
    private void Debug()
    {
        print("ended");
    }
}
