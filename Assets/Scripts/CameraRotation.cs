using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // 目标GameObject，相机将围绕它旋转
    public float speed = 10.0f; // 相机旋转的速度

    void Update()
    {
        if (target != null)
        {
            // 围绕目标旋转相机
            transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
        }
    }
}
