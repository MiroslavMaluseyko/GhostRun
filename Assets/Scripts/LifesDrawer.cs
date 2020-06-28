using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesDrawer : MonoBehaviour
{

    public List<GameObject> lifes;

    private Transform _transform;

    private int visibleLifes = 3;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        visibleLifes = GameManager.lifeCount;
    }

    public  void HideLife(int life)
    {
        lifes[life].SetActive(false);
    }
    public void ShowLife(int life)
    {
        for(int i = 0;i<life;i++)
          lifes[i].SetActive(true);
    }

    private void Update()
    {
        if(visibleLifes>GameManager.lifeCount)
        {
            visibleLifes = GameManager.lifeCount;
            HideLife(visibleLifes);
        }else
        if(visibleLifes < GameManager.lifeCount)
        {
            visibleLifes = GameManager.lifeCount;
            ShowLife(visibleLifes);
        }
    }

}
