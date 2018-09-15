using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlers : MonoBehaviour {

    public void GoToSiteHandler()
    {
        Debug.Log("My name is yon yonson");
        Application.OpenURL("http://www.brain-power.com");
        Debug.Log("I live in Wisconson");
    }

}
