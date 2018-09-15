using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchListener : MonoBehaviour
{

    [SerializeField]
    protected GameObject MenuGreyFilter;
    [SerializeField]
    protected GameObject Menu;
    [SerializeField]
    float MenuWidthPct;
    protected float MenuWidthAbs;



    Vector2 startPos = Vector2.left;
    Vector2 fastSwipeStartPos = Vector2.left;

    int MenuOpenState = 2; //2 = initial state //1 = menu is open //0 = menu is closed // 5= dont snap to nearest (prob bc animation is running)


    void Start()
    {
        MenuWidthAbs = MenuWidthPct * Screen.width;
    }



    void MenuOpenListener()
    {

        Touch touch = Input.GetTouch(0);

        if (fastSwipeStartPos == Vector2.left) { fastSwipeStartPos = touch.position; } //set fastSwipeStartPos
        if (fastSwipeStartPos.x > Screen.width * .2f || fastSwipeStartPos.y > Screen.height * .8f) { fastSwipeStartPos = Vector2.left; return; } //if the touch is too far to the right then the touch is not trying to open the menu, so return
        float deltaX = Mathf.Abs(touch.position.x - fastSwipeStartPos.x);          //this is the total delta touch

        float Velocity = touch.deltaPosition.x / touch.deltaTime;

        if (Velocity > 4000) { OpenMenu(); return; } //if the speed and direction are correct for a fast swipe then open menu





        Menu.GetComponent<Transform>().position = new Vector3(Mathf.Min(MenuWidthAbs, touch.position.x), 0, 0);

        if (Menu.GetComponent<Transform>().position.x > MenuWidthAbs * .9f) { OpenMenu(); return; }

        //upon touch ended snaps depending on how much user had swiped
        if (touch.phase == TouchPhase.Ended)
        {
            TouchEnded(.25f);
        }
    }


    void MenuCloseListerner()
    {
        Touch touch = Input.GetTouch(0);



        if (fastSwipeStartPos == Vector2.left) { fastSwipeStartPos = touch.position; } //set fastSwipeStartPos
        if (fastSwipeStartPos.x > Screen.width * .7f) { CloseMenu(); return; } //if you click to the right of the menu then close the menu
        float deltaX = Mathf.Abs(touch.position.x - fastSwipeStartPos.x);

        float Velocity = touch.deltaPosition.x / touch.deltaTime;

        if (Velocity < -4000) { CloseMenu(); return; }





        if (touch.position.x > Menu.GetComponent<Transform>().position.x * .85f)
        {
            Menu.GetComponent<Transform>().position = new Vector3(Mathf.Min(MenuWidthAbs, touch.position.x), 0, 0);


            //upon touch ended snaps depending on how much user had swiped
            if (touch.phase == TouchPhase.Ended)
            {
                TouchEnded(.4f);
            }

        }
    }

    public void OpenMenu()
    {
        fastSwipeStartPos = Vector2.left;
        Menu.GetComponent<Transform>().position = new Vector3(MenuWidthAbs, 0, 0);
        MenuOpenState = 1;
        startPos = Vector2.left;
        return;
    }
    public void CloseMenu()
    {
        fastSwipeStartPos = Vector2.left;
        Menu.GetComponent<Transform>().position = Vector3.left;
        MenuOpenState = 0;
        startPos = Vector2.left;
        return;
    }



    //////void MenuCloseListerner()
    //////{
    //////    Touch touch = Input.GetTouch(0);



    //////    if (fastSwipeStartPos == Vector2.left) { fastSwipeStartPos = touch.position; } //set fastSwipeStartPos
    //////    if (fastSwipeStartPos.x > Screen.width * .7f) { CloseMenu(); return; } //if you click to the right of the menu then close the menu

    //////    float deltaX = Mathf.Abs(touch.position.x - fastSwipeStartPos.x);

    //////    float Velocity = touch.deltaPosition.x / touch.deltaTime;

    //////    if (Velocity < -4000 )  { fastSwipeStartPos = Vector2.left; CloseMenu(); return; }


    //////    if (touch.phase == TouchPhase.Ended)
    //////    {
    //////        fastSwipeStartPos = Vector2.left;
    //////    }


    //////    if (touch.position.x > Menu.GetComponent<Transform>().position.x * .8f)
    //////    {
    //////        Menu.GetComponent<Transform>().position = new Vector3(Mathf.Min(MenuWidthAbs, touch.position.x), 0, 0);


    //////        //upon touch ended snaps depending on how much user had swiped
    //////        if (touch.phase == TouchPhase.Ended)
    //////        {
    //////            TouchEnded(.4f);
    //////        }

    //////    }
    //////}
    void TouchEnded(float snapToShowingMin)
    {



        //if user release less that 33% of the way there then snap to back to full menu
        if (Menu.GetComponent<Transform>().position.x > Screen.width * snapToShowingMin)
        {
            OpenMenu();
        }
        //if user releases more than 33% of the way to closed, then close menu
        else
        { CloseMenu(); }
    }



    // Update is called once per frame
    void Update()
    {
        MenuGreyFilter.GetComponent<Image>().color = new Color(160, 130, 130, Mathf.Max(0, (Menu.GetComponent<Transform>().position.x / MenuWidthAbs)));

        //Debug.Log(MenuOpenState);
        if (Input.touchCount > 0)
        {
            if (!(MenuOpenState == 1)) { MenuOpenListener(); }

            if (MenuOpenState == 1) { MenuCloseListerner(); }
        }
        if (Input.touchCount == 0 && MenuOpenState != 5)
        {

            TouchEnded(.3f);
        }
    }
}
