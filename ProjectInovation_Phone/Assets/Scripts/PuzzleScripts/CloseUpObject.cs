using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseUpObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite hint;
    [SerializeField] private GameObject target;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject o = Instantiate(target, Vector3.zero, Quaternion.identity,transform.parent);
        o.GetComponentInChildren<Image>().sprite = hint;
        Debug.Log("Clicked on object");
    }

}
