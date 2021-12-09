using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerBox player;
    public Menu UI;
    public Spawner spawner;
    private Coroutine scoreCounter;


    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetInt("Volume",1);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameValues.GameStarted)
        {
            if (scoreCounter == null) scoreCounter = StartCoroutine(ScoreAdding());
            Time.timeScale = GameValues.TimeScale;

            
            if (!spawner.isActiveAndEnabled)
            {
                spawner.gameObject.SetActive(true);
            }
            if (GameValues.GamePaused && Time.timeScale > 0)
            {
                Time.timeScale = 0;

            }
            else
            if (!GameValues.GamePaused && Time.timeScale == 0)
            {
                Time.timeScale = GameValues.TimeScale;
            }
            if (!player.Alive && !GameValues.GamePaused)
            {
                if (!GameValues.Rised)
                {
                    GameValues.Rised = true;
                    UI.Death();
                }
                else
                {
                    UI.End();
                }
            }
        }else
        {
            if(scoreCounter != null)StopCoroutine(scoreCounter);
        }

    }

    public void Rise(int x)
    {
        player.Alive = true;
        player.lifes = x;
        foreach (EnemyMover enemy in Spawner.enemyPool)
        {
            Destroy(enemy.gameObject);
        }
        Spawner.enemyPool.Clear();
    }

    private IEnumerator ScoreAdding()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameValues.Score++;
            if (GameValues.Score <= 100)
            {
                if (GameValues.Score % 10 == 0) GameValues.TimeScale += 0.05f;
            }
            else
            {
                if (GameValues.Score % 50 == 0) GameValues.TimeScale += .1f;
            }
        }
    }
}
