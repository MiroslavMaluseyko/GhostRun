using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spawner.enemyPool.Remove(this);
        Destroy(gameObject);
    }
}
