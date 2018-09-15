using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSizer : MonoBehaviour {
    [SerializeField]
    GameObject Go;
    RectTransform RectX;

    // Use this for initialization
    void Start () {
       
        RectX = Go.GetComponent<RectTransform>();
        RectX.sizeDelta = new Vector2(Screen.width*.6f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
