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
    // Start is called before the first frame update
    void Start()
    {
        //OnVideoEnd.AddListener(Debug);
    }

    public void Play()
    {
        playerTarget.SetActive(true);
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
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
