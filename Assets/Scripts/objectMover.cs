using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMover : MonoBehaviour
{
    public float speed;

    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.position += Vector3.left * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
