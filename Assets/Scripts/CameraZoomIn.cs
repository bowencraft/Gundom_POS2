using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float min = 20f;
    [SerializeField]
    public float max = 60f;


    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomCamera(-speed);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomCamera(speed);
        }
    }

    void ZoomCamera(float change)
    {
        float newView = Mathf.Clamp(Camera.main.fieldOfView + change, min, max);
        Camera.main.fieldOfView = newView;
    }
}
