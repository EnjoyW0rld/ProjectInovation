using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskGeneral : MonoBehaviour
{
    public UnityEvent OnComplete;
    public void SetComplete()
    {
        FindObjectOfType<PuzzleManager>().OnPuzzleDone();
    }
}
