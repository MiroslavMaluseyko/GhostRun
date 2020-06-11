using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroyer : MonoBehaviour
{
    Rect _camRect;
    Transform _transform;
    void Start()
    {
        _camRect = Camera.main.rect;
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_transform.position.x + 2 < Camera.main.ViewportToWorldPoint(new Vector3(_camRect.x, _camRect.y)).x)
        {
            Destroy(gameObject);
        }
    }
}
