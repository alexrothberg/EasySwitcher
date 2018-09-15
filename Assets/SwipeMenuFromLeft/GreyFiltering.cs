using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreyFiltering : TouchListener {


    float tt;

    void Start()
    {
        ////tt = MenuGreyFilter.GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update () {

        //tt= Mathf.Min(0, (Menu.GetComponent<Transform>().position.x / MenuWidthAbs) * 128);
        ////tt++;
        ////MenuGreyFilter.GetComponent<Image>().color = new Color(160, 130, 130, tt);
        ////Debug.Log("TT:  "+ tt);
        //Debug.Log("COLOR :  " + MenuGreyFilter.GetComponent<Image>().color);
        Debug.Log("COLOR A:  " + MenuGreyFilter.GetComponent<Image>().color.a);


    }
}
