using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnMusicButton : MonoBehaviour
{
    private AudioSource music;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        music = GetComponent<AudioSource>();

    }

    public void Turn()
    {
        GameManager.TurnMusic();
    }
}
