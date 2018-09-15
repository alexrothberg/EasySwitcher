using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Highlighter : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Image>().color = new Color(229, 217, 217);
        Debug.Log("HI");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
    }

    
}
