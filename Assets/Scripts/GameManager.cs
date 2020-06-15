using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class GameManager : ScriptableObject
{
    static public float timeSpeed = 1;

    static public float distance = 0;

    private void Awake()
    { 

        if(!PlayerPrefs.HasKey("maxDistance"))
        {
            PlayerPrefs.SetInt("maxDistance",0);
        }
    }

}
