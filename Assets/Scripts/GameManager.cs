using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class GameManager : ScriptableObject
{
    static public float timeSpeed = 1;

    static public float distance = 0;

    static public int lifeCount = 3;


    private void Awake()
    {

        if(!PlayerPrefs.HasKey("maxDistance"))
        {
            PlayerPrefs.SetInt("maxDistance",0);
        }
    }

    static public void SaveBestDist()
    {
        if (distance / 10 > PlayerPrefs.GetInt("maxDistance"))
        {
            PlayerPrefs.SetInt("maxDistance", (int)distance / 10);
        }
    }

    static public void TurnMusic()
    {
        AudioListener.volume = 1 - AudioListener.volume;
    }

    static public bool LifesOver()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        lifeCount--;
        return 0 == lifeCount;
    }
}
