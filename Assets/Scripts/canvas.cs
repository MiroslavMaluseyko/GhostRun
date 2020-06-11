using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class canvas : MonoBehaviour
{

    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject deathMenu;


    private Rect rect;
    private RectTransform trans;

    private void Awake()
    {
        trans = pauseButton.GetComponent<RectTransform>();
        rect = Camera.main.pixelRect;

        trans.sizeDelta = new Vector2(rect.height / 8, rect.height / 8);
        Vector2 pos = new Vector2(-rect.width/2, rect.height/2);
        pos += new Vector2(rect.height/8, -rect.height/8);
        trans.localPosition = pos;

        menuConstructor(pauseMenu);
        menuConstructor(deathMenu);
        
    }

    private void menuConstructor(GameObject menu)
    {
        Transform[] children = menu.GetComponentsInChildren<Transform>();

        float buttonHeight = rect.height / 4.5f;

        int count = children.Length - 1;
        float dx = 0.1f * buttonHeight;
        float x = -(count / 2) * (buttonHeight + dx);

        if(count%2 == 0)
        {
            x += buttonHeight + dx;
        }


        RectTransform trans = menu.GetComponent<RectTransform>();
        trans.localPosition = Vector2.zero;
        trans.sizeDelta = new Vector2(buttonHeight * count, buttonHeight);

        foreach (Transform child in children)
        {
            if (child.gameObject == menu) continue;
            trans = child.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(buttonHeight, buttonHeight);
            trans.localPosition = new Vector2(x, 0);
            x += buttonHeight + dx;
        }
    }

}
