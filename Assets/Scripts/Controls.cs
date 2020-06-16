using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : ScriptableObject
{
    // Start is called before the first frame update
    //[Header("Swipes")]
    static public float maxSwapTime;
    static public float minSwipeDistance;

    static private float swipeStartTime;
    static  float swipeEndTime;
    static private float swipeTime;

    static private Vector2 startSwipePosition;
    static private Vector2 endSwipePosition;
    static private float swipeLength;


    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    static public bool GetInput(Direction dir)
    {
        if(PCControls(dir)) return true;
        if (AndroidControls(dir)) return true;
        return false;

    }

    static private  bool PCControls(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return (Input.GetKeyDown(KeyCode.UpArrow));
            case Direction.Down:
                return (Input.GetKeyDown(KeyCode.DownArrow));
            case Direction.Left:
                return (Input.GetKey(KeyCode.LeftArrow));
            case Direction.Right:
                return (Input.GetKey(KeyCode.RightArrow));
            default: return false;
        }
    }

    static private bool AndroidControls(Direction dir)
    {
        if (!SwipeTest()) return false;

        Direction realDir;

        Vector2 Distance = endSwipePosition - startSwipePosition;

        float DistanceX = Mathf.Abs(Distance.x);
        float DistanceY = Mathf.Abs(Distance.y);

        if (DistanceX < DistanceY)
        {
            if (Distance.y < 0)
                realDir = Direction.Down;
            else
                realDir = Direction.Up;
        }
        else
        {
            if (Distance.x < 0)
                realDir = Direction.Left;
            else
                realDir = Direction.Right;
        }
        //Debug.Log(realDir);
        return (dir == realDir);
    }

     static private bool SwipeTest()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    swipeStartTime = Time.time;
                    startSwipePosition = touch.position;
                    // Debug.Log("Start");
                    break;

               /* case TouchPhase.Moved:
                    //  Debug.Log("Moving");
                    break;*/
                case TouchPhase.Moved:

                    swipeEndTime = Time.time;
                    endSwipePosition = touch.position;
                    swipeTime = swipeEndTime - swipeStartTime;
                    swipeLength = (endSwipePosition - startSwipePosition).magnitude;

                    //Debug.Log(swipeTime + "    " + swipeLength + "    ");
                    //Debug.Log("End");

                    return (swipeTime < maxSwapTime && swipeLength > minSwipeDistance);
                    break;

            }
        }
        return false;
    }

}
