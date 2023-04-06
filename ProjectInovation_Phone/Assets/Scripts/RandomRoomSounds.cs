using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMult = 0.2f;
    public float allVolume = 0.2f;

    public float minTime = 1f;
    public float maxTime = 10f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.volume = allVolume;
            source.pitch = Random.Range(1 - pitchChangeMult, 1 + pitchChangeMult);
            source.PlayOneShot(source.clip);
            timer = Random.Range(minTime, maxTime);
        }
    }
}
