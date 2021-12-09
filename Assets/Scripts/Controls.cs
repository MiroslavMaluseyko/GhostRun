using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Controls
{
	public const float MAX_SWIPE_TIME = 0.5f;

	public const float MIN_SWIPE_DISTANCE = 0.05f;

	static bool swipedUp;
	static bool swipedDown;


	static private Vector2 startPos;
	static private float startTime;

	static public Direction GetControls()
    {
		Swipe();
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || swipedUp)
        {
            return Direction.Up;
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || swipedDown)
        {
            return Direction.Down;
        }
        return Direction.None;
    }

    static private void Swipe()
    {
		swipedUp = false;
		swipedDown = false;


		if (Input.touchCount > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began)
			{
				startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
				startTime = Time.time;
			}
			if (t.phase == TouchPhase.Ended)
			{
				if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
					return;

				Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

				Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

				if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
					return;

				if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
				{ // Horizontal swipe
					if (swipe.x > 0)
					{
						//swipedRight = true;
					}
					else
					{
						//swipedLeft = true;
					}
				}
				else
				{ // Vertical swipe
					if (swipe.y > 0)
					{
						swipedUp = true;
					}
					else
					{
						swipedDown = true;
					}
				}
			}
		}

	}
}
