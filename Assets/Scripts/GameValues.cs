using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{
    public Vector3[] positions;

    static public Vector3[] position;
    static public bool GamePaused;
    static public bool GameStarted;
    static public bool Rised;
    static public int Score;
    static public float TimeScale;

    // Start is called before the first frame update
    void Awake()
    {
        position = positions;
        GamePaused = false;
        GameStarted = false;
        Rised = false;
        Score = 0;
    }

    static public void ToDefault()
    {
        GameStarted = true;
        GamePaused = false;
        Rised = false;
        Score = 0;
        TimeScale = 1f;
    }

}
