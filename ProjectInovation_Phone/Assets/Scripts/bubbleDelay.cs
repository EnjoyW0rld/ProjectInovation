using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleDelay : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            animator.Play("bubbleAnimation");
            yield return new WaitForSeconds(9);
            animator.Play("Default");
            print("ayayaya");
        }
    }

}
