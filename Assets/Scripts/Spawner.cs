using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float delay;

    public List<EnemyMover> groundEnemy;
    public List<EnemyMover> skyEnemy;

    [HideInInspector]
    static public List<EnemyMover> enemyPool;


    void Start()
    {
        enemyPool = new List<EnemyMover>();
        StartCoroutine(Spawn());
    }


    private IEnumerator Spawn()
    {
        while (true)
        {
            int space = Random.Range(0, 3);

            yield return new WaitForSeconds(delay);

            for(int i = 0;i<3;i++)
            {
                if (space == i) continue;
                if (i < 2) enemyPool.Add(Instantiate(skyEnemy[Random.Range(0, skyEnemy.Count)], GameValues.position[i]+Vector3.right*40,Quaternion.identity));
                else enemyPool.Add(Instantiate(groundEnemy[Random.Range(0, groundEnemy.Count)], GameValues.position[i]+Vector3.right*40,Quaternion.identity));
            }
        }
    }

}
