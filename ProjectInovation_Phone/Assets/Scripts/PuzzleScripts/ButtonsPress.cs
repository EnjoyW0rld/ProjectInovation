using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonsPress : TaskGeneral
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int[] sequence;
    //[HideInInspector] public UnityEvent OnSequnceComplete;
    [SerializeField] private UnityEvent OnError;
    [SerializeField] private AudioSource correctSound;
    private ClickHandler[] clickObjects;
    private int nextToPress;

    private void Start()
    {
        clickObjects = new ClickHandler[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            clickObjects[i] = buttons[i].AddComponent<ClickHandler>();
            clickObjects[i].OnPointerClicked.AddListener(ClickedOnObject);
            clickObjects[i].SetObjID(i);
        }
    }

    // Update is called once per frame
    /**
    void Update()
    {
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            //Touch touch = Input.GetTouch(0);
            Touch touch = getTouch();

            Vector3 pos = CameraToWorld(touch.position);
            print(pos);
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].OverlapPoint(pos))
                {
                    print("touched " + buttons[i].name);
                }
            }
        }
    }
    /**/

    private void ClickedOnObject(int id)
    {
        if (sequence[nextToPress] == id)
        {
            nextToPress++;
            if (nextToPress == sequence.Length) { 
                print("Done!");
                correctSound.Play();
            }
        }
        else
        {
            OnError?.Invoke();
            print("Incorrect pressed");
            nextToPress = 0;
        }
    }



}
