using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    public int lifes = 1;
    [HideInInspector]
    public bool Alive;


    void Start()
    {
        Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            if (lifes <= 0)
            {
                Alive = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            lifes--;
            Destroy(collision.gameObject);
        }
    }

}
