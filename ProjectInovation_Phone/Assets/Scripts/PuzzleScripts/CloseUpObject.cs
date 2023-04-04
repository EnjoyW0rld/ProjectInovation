using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseUpObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject prefab;
    public void OnPointerClick(PointerEventData eventData)
    {
        //target.SetActive(true);

        Instantiate(prefab, Vector3.zero, Quaternion.identity,transform.parent);
        Debug.Log("Clicked on object");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
