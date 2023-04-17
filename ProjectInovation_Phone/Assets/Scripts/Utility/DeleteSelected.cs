using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelected : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public bool needDelete;
    /*private CloseUpObject closeUpObject;
    private void Start()
    {
        closeUpObject = GameObject.FindWithTag("Hint").GetComponent<CloseUpObject>();
    }*/
    private void Update()
    {
        if (needDelete)
        {
            DestroyTarget();
        }
    }

    public void DestroyTarget()
    {
        Destroy(target);
    }
}
