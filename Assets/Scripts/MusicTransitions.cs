using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransitions : MonoBehaviour
{
    private static MusicTransitions instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }
}
