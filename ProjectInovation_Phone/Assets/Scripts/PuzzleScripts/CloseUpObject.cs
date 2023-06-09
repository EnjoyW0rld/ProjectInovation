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
        if (target.TryGetComponent<TaskGeneral>(out TaskGeneral taskGeneral))
        {
            Instantiate(target, Vector3.zero, Quaternion.identity, transform.parent);
        }
        else
        {
            GameObject o = Instantiate(target, Vector3.zero, Quaternion.identity, transform.parent);
            //o.GetComponentInChildren<Image>().sprite = hint;
            
            
            var imgs = o.GetComponentsInChildren<Image>();
            print(imgs.Length); 
            for (int i = 0; i < imgs.Length; i++)
            {

                if (imgs[i].tag == "hintImage")
                {
                    imgs[i].sprite = hint;
                    break;
                }
            }

             
            Debug.Log("Clicked on object");
        }
    }


}
