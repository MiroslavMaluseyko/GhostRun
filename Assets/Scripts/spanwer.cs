using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spanwer : MonoBehaviour
{
    public float interval;
    public int rowCount;
    public GameObject[] airObjects;
    public GameObject[] groundObjects;

    static public List<GameObject> objects;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Spawn()
    {

        for (;;)
        {
            yield return new WaitForSeconds(interval);
            int spaceIndex = Random.Range(0, rowCount);
            float yCoord = -5;
            if (spaceIndex != 0)
            {
                Instantiate(groundObjects[Random.Range(0, groundObjects.Length)]);
            }
            for (int i = 1;i<rowCount;i++)
            {
                yCoord += 5;
                if (spaceIndex == i) continue;
                Instantiate(airObjects[Random.Range(0, airObjects.Length)], new Vector2(-5, yCoord), new Quaternion());
            }
        }
    }
}
