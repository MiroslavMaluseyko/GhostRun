using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text score;
    public PlayerBox player;

    public List<GameObject> hearts;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Mathf.RoundToInt(GameValues.Score).ToString();
        for(int i = 0;i<hearts.Count;i++)
        {
            if (i >= player.lifes) hearts[i].SetActive(false);
            else hearts[i].SetActive(true);
        }

    }
}
