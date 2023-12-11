using System;
using System.Numerics;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public Transform target; // 目标物体
    public float sensitivity = 100f; // 鼠标灵敏度
    public float distanceFromTarget = 5f; // 摄像机与目标物体的距离

    private float mouseX = 0f;
    private float mouseY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 锁定光标到屏幕中心
    }

    void Update()
    {
        // 获取鼠标输入
        mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -35, 60); // 限制垂直旋转角度

        // 计算摄像机的旋转
        transform.LookAt(target); // 始终朝向目标物体
        transform.RotateAround(target.position, UnityEngine.Vector3.up, mouseX);
        transform.RotateAround(target.position, transform.right, mouseY);

        // 确保摄像机保持固定距离
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
