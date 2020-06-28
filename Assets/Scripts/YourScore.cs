using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;

    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        text.text = (int)GameManager.distance/10 + "";
    }
}
