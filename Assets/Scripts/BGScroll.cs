using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float speedX;
    public float speedY;

    private Vector2 offset;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(speedX, speedY);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
