using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMover : MonoBehaviour
{
    public float speed;

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Repeat(Time.time * speed, 1);
        Vector2 offset = new Vector2(x, 0);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
