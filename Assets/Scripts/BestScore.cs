﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{

    private Text text;

    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
       text.text = PlayerPrefs.GetInt("maxDistance") + "";
    }
}
