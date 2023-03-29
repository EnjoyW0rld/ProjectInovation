using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class MicrophoneInpute : MonoBehaviour
{
    private AudioSource audio_source;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI peakText;
    private AudioMixerGroup mixerGroup;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();

        //add the rest of the code like this
        audio_source.clip = Microphone.Start(null, true, 10, 44100);
        audio_source.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audio_source.Play();

        mixerGroup = audio_source.outputAudioMixerGroup;

        clipSampleData = new float[1024];
    }

    float[] clipSampleData;
    // Update is called once per frame
    [SerializeField] float peak = 0;
    void Update()
    {
        float v;
        //mixerGroup.audioMixer.GetFloat("Volume", out v);
        
        audio_source.clip.GetData(clipSampleData, audio_source.timeSamples);
        float clipLoudness = 0f;
        for (int i = 0; i < 1024; i++)
        {
            clipLoudness += Mathf.Abs(clipSampleData[i]);
        }
        clipLoudness /= clipSampleData.Length;
        text.text = clipLoudness + "";
        if(peak < clipLoudness) peak = clipLoudness;
        peakText.text = peak + "";
        if (clipLoudness > 0.3f) Camera.main.backgroundColor = Color.red;
        else Camera.main.backgroundColor = Color.blue;
    }
}
