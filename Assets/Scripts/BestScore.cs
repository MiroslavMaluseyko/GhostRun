using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Yours: " + (int)GameManager.distance/10 + "\nBest: " + PlayerPrefs.GetInt("maxDistance");

    }

    // Update is called once per frame
    void Update()
    {
    }
}
