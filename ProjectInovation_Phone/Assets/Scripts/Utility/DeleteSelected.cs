using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelected : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    /*private CloseUpObject closeUpObject;
    private void Start()
    {
        closeUpObject = GameObject.FindWithTag("Hint").GetComponent<CloseUpObject>();
    }*/

    public void DestroyTarget()
    {
        Destroy(target);
    }
}
