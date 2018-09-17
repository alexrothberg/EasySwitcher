using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonController : MonoBehaviour, IPointerDownHandler{

    //joystick will refer to the combination of light blue bg halo and options text
    //button will refer to the white button with shadow that is always visible
    //joystick nub will refer to that button when it can be moved around

  
    bool usingFrozen = true;
    Vector2 nubStartPos;

    public Text txt;

    string OptionChosen;

    bool B_Joystick_Visible = false;

    public GameObject Nub;

    public GameObject Joystick;
    public Touch touch;
    Vector3 Shrinker = new Vector3(.01f, .01f, .01f);
    private void Start()
    {
        nubStartPos = Nub.transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Nub.SetActive(true);
        Joystick.SetActive(true);

        B_Joystick_Visible = true;
        ShrinkNub();
    }

    // Update is called once per frame
    void Update()
    {
        if (B_Joystick_Visible) //this checks to see whether the joystick is visible and behaves accordingly
        {
            touch = Input.GetTouch(0);
            if (usingFrozen)
            {
                if (Vector3.Distance(nubStartPos, touch.position) < 190) { Nub.transform.position = touch.position; }
                else { Nub.transform.localPosition = Vector3.Normalize( (touch.position - nubStartPos)) * 65; }                
                
                ButtonSelected(65, false); 
                //ButtonSelected(30, false); //this will tell what to highlight

            }
            else
            {
                Nub.transform.position = touch.position; //this binds the nub to finger
                ButtonSelected(60, true);//this will snap to choosing the region
            }



                if (touch.phase == TouchPhase.Ended)
            {
                ButtonSelected(45,true);
                CloseJS();
                
              
            }
        }
    }





    void ShrinkNub()
    {
        if (!B_Joystick_Visible) { return; }
        Nub.transform.localScale = Nub.transform.localScale - Shrinker;

        if (Nub.transform.localScale.magnitude > .85) { Invoke("ShrinkNub", .01f); }
    }


    void RegionActionHandler() ///////////////put the scripts for depressing the buttons here
    {
        txt.text = OptionChosen;   ///////////take this out it was just for debug
        switch (OptionChosen)
        {
            case "topRight":

                Debug.Log("TR");
                break;

            case "bottomRight":
                Debug.Log("BR");
                break;
            case "topLeft":
                Debug.Log("TL");
                break;
            case "bottomLeft":
                Debug.Log("BL");
                break;


        }
    }

    void ButtonSelected(int NubDisplacement, bool wantToPressIfGreater)
    {
        if (Nub.transform.localPosition.magnitude > NubDisplacement)
        {


            if (Nub.transform.localPosition.x > 0)
            {
                if (Nub.transform.localPosition.y > 0) { OptionChosen = "topRight"; }
                else { OptionChosen = "bottomRight"; }
            }
            else
            {
                if (Nub.transform.localPosition.y > 0) { OptionChosen = "topLeft"; }
                else { OptionChosen = "bottomLeft"; }
            }

            RegionActionHandler();
            if (wantToPressIfGreater) { CloseJS(); return; }
            
            
        }
    
    }
    
    public void ToggleSnap()
    {
        usingFrozen = !usingFrozen;
    }

    void CloseJS()
    {
        if (!B_Joystick_Visible) { return; }
        Nub.transform.localScale = Vector3.one;
        Nub.transform.localPosition = Vector3.zero;
        Joystick.SetActive(false);
        B_Joystick_Visible = false;
    }

}
