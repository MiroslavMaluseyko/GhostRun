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
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Rise()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
    }

}
