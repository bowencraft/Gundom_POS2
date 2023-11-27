using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{
    public float speed = 2f;
    public float min = 20f;
    public float max;
    Camera cam;


    void Start()
    {
        cam = Camera.main;
        max = cam.fieldOfView;
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomCamera(-speed);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomCamera(speed);
        }
    }

    void ZoomCamera(float change)
    {
        float changeView = cam.fieldOfView + change;
        Camera.main.fieldOfView = Mathf.Clamp(changeView, min, max);
    }
}
