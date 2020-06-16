using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class menu : MonoBehaviour
{

    public GameObject player;
    public GameObject pauseMenu;

    private playerController pc;

    private void Start()
    {
        pc = player.GetComponent<playerController>();
    }

    public void Pause()
    {
        Time.timeScale  = 0;
        pauseMenu.SetActive(true);
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
            playerController.alive = true;
            pc.deathMenu.SetActive(false);
            Resume();
            Pause();
        }
    }


    public void ToMainMenu()
    {
        Time.timeScale = 1;
        GameManager.timeSpeed = 1;
        GameManager.distance = 0;
        SceneManager.LoadScene(0);
        //SceneManager.UnloadSceneAsync(1);
    }
}
