using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonController : MonoBehaviour,IPointerDownHandler {

    //joystick will refer to the combination of light blue bg halo and options text
    //button will refer to the white button with shadow that is always visible
    //joystick nub will refer to that button when it can be moved around

    string OptionChosen;

    bool B_Joystick_Visible = false;

    public GameObject Nub;
   
    public GameObject Joystick;
    public Touch touch;
    Vector3 Shrinker = new Vector3(.01f, .01f, .01f);

    public void OnPointerDown(PointerEventData eventData)
    {
       
        Nub.SetActive(true);
        Joystick.SetActive(true);

        B_Joystick_Visible = true;
        ShrinkNub();
    }

    // Update is called once per frame
    void Update() {
        if (B_Joystick_Visible) //this checks to see whether the joystick is visible and behaves accordingly
        {
            touch = Input.GetTouch(0);

            Nub.transform.position = touch.position;
            //Debug.Log(touch.position);
            //Debug.Log(Nub.transform.position);

            //if (touch.phase == TouchPhase.Ended)
            //{
            //    Nub.transform.localScale = Vector3.one;

            //    B_Joystick_Visible = false;
            //}
            if (Nub.transform.localPosition.magnitude > 60)
            {
                if (Nub.transform.localPosition.x > 0)
                {
                    if (Nub.transform.localPosition.y > 0) { Debug.Log("topRight"); }
                    else { Debug.Log("bottomRight"); }
                }
                else
                {
                    if (Nub.transform.localPosition.y > 0) { Debug.Log("topLeft"); }
                    else { Debug.Log("bottomLeft"); }
                }
                Nub.transform.localScale = Vector3.one;
                Nub.transform.localPosition = Vector3.zero;
                Joystick.SetActive(false);
                B_Joystick_Visible = false;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (Nub.transform.localPosition.magnitude > 45)
                {
                    if (Nub.transform.localPosition.x > 0)
                    {
                        if (Nub.transform.localPosition.y > 0) { Debug.Log("topRight"); }
                        else { Debug.Log("bottomRight"); }
                    }
                    else
                    {
                        if (Nub.transform.localPosition.y > 0) { Debug.Log("topLeft"); }
                        else { Debug.Log("bottomLeft"); }
                    }

                }
                Nub.transform.localScale = Vector3.one;
                Nub.transform.localPosition = Vector3.zero;
                Joystick.SetActive(false);
                B_Joystick_Visible = false;
            }
        }
    }


       


void ShrinkNub()
    {
        if (!B_Joystick_Visible) { return; }
        Nub.transform.localScale = Nub.transform.localScale - Shrinker;
       
        if (Nub.transform.localScale.magnitude > .85 ) { Invoke("ShrinkNub", .01f); }
    }


 void RegionActionHandler()
    {
        switch (OptionChosen)
        {
            case "TR":

                Debug.Log("TR");
                break;

            case "BR":
                Debug.Log("BR");
                break;
            case "TL":
                Debug.Log("TL");
                break;
            case "BL":
                Debug.Log("BL");
                break;
                

        }
    }

 

    }
