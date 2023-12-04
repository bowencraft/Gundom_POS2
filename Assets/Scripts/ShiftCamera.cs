using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCamera : MonoBehaviour
{
    private int index;
    [SerializeField]
    private Camera[] cameras;

    void Start()
    {
        cameras = FindObjectsOfType<Camera>();
        index = 0;
        for(int i = 0; i < cameras.Length; i++)
        {
            if(i == index)
            {
                Enable(cameras[i]);
            }
            else
            {
                Disable(cameras[i]);
            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        index = index % cameras.Length;
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == index)
            {
                Enable(cameras[i]);
            }
            else
            {
                Disable(cameras[i]);
            }
        }
        index++;
    }

    void Enable(Camera camera)
    {
        camera.enabled = true;
    }

    void Disable(Camera camera)
    {
        camera.enabled = false;
    }
}
