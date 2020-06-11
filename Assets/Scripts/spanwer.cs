using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spanwer : MonoBehaviour
{
    public float interval;
    public GameObject[] objects;
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
            Instantiate(objects[Random.Range(0,objects.Length)]);
        }
    }
}
