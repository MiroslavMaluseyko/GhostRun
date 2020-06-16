using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void StartGame()
    {
        Time.timeScale = 1;
        GameManager.timeSpeed = 1;
        SceneManager.LoadScene(1);
       // SceneManager.UnloadSceneAsync(0);
    }
   

    public void QuitGame()
    {
        Application.Quit();
    }


}
