using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDontDestroyOnLoad : MonoBehaviour
{
    private static AudioDontDestroyOnLoad bgMusic;

    private void Awake()
    {
        if (bgMusic == null)
        {
            bgMusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
