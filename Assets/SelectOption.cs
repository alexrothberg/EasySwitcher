using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SelectOption : MonoBehaviour,IPointerExitHandler, IPointerUpHandler {



    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(gameObject + " was selected");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(gameObject + " was selected");
    }
}
