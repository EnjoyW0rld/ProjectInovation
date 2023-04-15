using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationDelay : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private int waitingTime, animationDuration;
    //[SerializeField] private string animationName;
    private int totalWait;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimation());
        totalWait = waitingTime + animationDuration;
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            animator.Play("Animation");
            yield return new WaitForSeconds(totalWait);
            animator.Play("Default");
            //print("ayayaya");
        }
    }

}
