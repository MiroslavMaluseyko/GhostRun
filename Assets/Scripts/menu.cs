using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameplayMenuUI;
    public GameObject deathMenuUI;
    public GameObject riseMenuUI;
    public GameObject mainUI;

    [Header("Manager")]
    public GameManager gameManager;
    [Header("Texts")]
    public Text bestScore;
    private Coroutine waiting;

    private void Start()
    {
        GameValues.GameStarted = false;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameValues.GamePaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    public void Play()
    {
        GameValues.ToDefault();
        gameplayMenuUI.SetActive(true);
        mainUI.SetActive(false);
        deathMenuUI.SetActive(false);
        riseMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);

    }

    public void Resume()
    {
        gameplayMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        mainUI.SetActive(false);
        deathMenuUI.SetActive(false);
        riseMenuUI.SetActive(false);
        GameValues.GamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameplayMenuUI.SetActive(false);
        mainUI.SetActive(false);
        deathMenuUI.SetActive(false);
        riseMenuUI.SetActive(false);
        GameValues.GamePaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        GameValues.ToDefault();
        SceneManager.LoadScene(0);
    }

    public void Death()
    {
        GameValues.GamePaused = true;
        riseMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        gameplayMenuUI.SetActive(false);
        mainUI.SetActive(false);
        deathMenuUI.SetActive(false);
        waiting = StartCoroutine(RiseWaiting());
    }

    public void Rise()
    {
        StopCoroutine(waiting);
        gameManager.Rise(1);
        AdsManager.ShowRewarded();
        Resume();
    }

    public void Retry()
    {
        gameManager.Rise(3);
        Play();
    }

    public void End()
    {
        float best = PlayerPrefs.GetInt("BestScore",0);
        if (GameValues.Score > best)
        {
            PlayerPrefs.SetInt("BestScore", GameValues.Score);
        }
        best = PlayerPrefs.GetInt("BestScore", 0);
        int your = GameValues.Score;
        bestScore.text = $"Best score: {best.ToString()} \nYour score: {your.ToString()}";
        StopCoroutine(waiting);
        GameValues.GamePaused = true;
        deathMenuUI.SetActive(true);
        riseMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameplayMenuUI.SetActive(false);
        mainUI.SetActive(false);
    }

    private IEnumerator RiseWaiting()
    {
        yield return new WaitForSecondsRealtime(4);
        End();
        yield return null;
    }

    public void Sound()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
        PlayerPrefs.SetInt("Volume",(int)AudioListener.volume);
    }

}
