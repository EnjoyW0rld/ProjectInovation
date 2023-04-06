using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseUpObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite hint;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject audioObject;

    private AudioSource audioSource;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (target.TryGetComponent<TaskGeneral>(out TaskGeneral taskGeneral))
        {
            Instantiate(target, Vector3.zero, Quaternion.identity, transform.parent);
        }
        else
        {
            GameObject o = Instantiate(target, Vector3.zero, Quaternion.identity, transform.parent);
            o.GetComponentInChildren<Image>().sprite = hint;
            Debug.Log("Clicked on object");

            if (audioObject)
            {
                audioSource = audioObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }

    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}
