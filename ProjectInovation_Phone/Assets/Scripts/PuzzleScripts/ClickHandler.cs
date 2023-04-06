using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public UnityEvent<int> OnPointerClicked = new UnityEvent<int>();
    private int objId;
    public void SetObjID(int id)
    {
        objId = id;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerClicked?.Invoke(objId);
    }

}
