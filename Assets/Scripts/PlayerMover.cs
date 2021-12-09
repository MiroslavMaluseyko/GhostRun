using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private enum Position
    {
        Top,
        Mid,
        Bot,
        None
    }

    private Position curPosition;
    private Position lastPosition;
    private Coroutine movingCoroutine;

    void Start()
    {
        curPosition = Position.Mid;
        lastPosition = Position.None;
        //movingCoroutine = StartCoroutine(Move(GameValues.position[(int)curPosition]));
    }

    void Update()
    {
        if (Controls.GetControls() == Direction.Up)
        {
            if (curPosition == Position.Bot)
            {
                curPosition = Position.Mid;
            }
            else
            {
                curPosition = Position.Top;
            }
        }
        if (Controls.GetControls() == Direction.Down)
        {
            if (curPosition == Position.Top)
            {
                curPosition = Position.Mid;
            }
            else
            {
                curPosition = Position.Bot;
            }
        }

        if(GameValues.GameStarted && curPosition != lastPosition)
        {
            lastPosition = curPosition;
            
            if(movingCoroutine != null)StopCoroutine(movingCoroutine);
            movingCoroutine = StartCoroutine(Move(GameValues.position[(int)curPosition]));
        }
    }

    private IEnumerator Move(Vector3 target)
    {
        Vector3 start = transform.position;
        for(float i = 0;i<1;i+=Time.deltaTime*2)
        {
            transform.position = Vector3.Lerp(start,target,EasyngSmoothSquared(i));
            yield return null;
        }
        transform.position = target;
    }

    private float EasyngSmoothSquared(float x)
    {
        return x < 0.5 ? x * x * 2 : (1-(1-x)*(1-x)*2);
    }
}
