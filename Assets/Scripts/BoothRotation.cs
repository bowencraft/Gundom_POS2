using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoothRotation : MonoBehaviour
{
    public LayerMask layerMask = 5;

    public GameObject rotateObject; // 你想要旋转的物体
    private bool isRotating = false;
    private Vector3 lastMousePosition;
    public int rotationSpeed;

    void Update()
    {
        // 检测鼠标按下事件
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Transform hitObject = hit.collider.transform;

                while (hitObject != null)
                {
                    //Debug.Log(hitObject);
                    if (hitObject.gameObject == gameObject)
                    {
                        lastMousePosition = Input.mousePosition;
                        isRotating = true;

                        break;
                    } else
                    {
                        hitObject = hitObject.parent;
                    }
                }

            }
        }

        // 检测鼠标释放事件
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        // 如果正在旋转
        if (isRotating)
        {
            // 计算鼠标移动的差值
            Vector3 delta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            // 将鼠标移动转换为旋转量
            Vector3 rotation = new Vector3(0, -delta.x, 0) * Time.deltaTime;

            // 应用旋转
            rotateObject.transform.Rotate(rotation * rotationSpeed, Space.World); // 旋转速度可以调整
        }
    }
}
