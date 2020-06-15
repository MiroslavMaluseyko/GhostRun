using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
   public void Pause()
    {
        Time.timeScale  = 0;
    }
    public void Resume()
    {
        Time.timeScale =  GameManager.timeSpeed;
    }

    public void Replay()
    {
        GameManager.timeSpeed = 1;
        Time.timeScale = GameManager.timeSpeed;
        GameManager.distance = 0;
        SceneManager.LoadScene(1);
    }

    public void Rise()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
    }


    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
