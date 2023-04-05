using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelected : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public void DestroyTarget()
    {
        Destroy(target);
    }
}
