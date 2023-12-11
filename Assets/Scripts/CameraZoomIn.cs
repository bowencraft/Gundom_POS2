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
    private float max = 60f;
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
        }else if (Input.GetAxis("Mouse ScrollWheel") < 0)
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
