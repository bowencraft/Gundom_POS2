using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointObject : MonoBehaviour
{
    //public enum JointType
    //{
    //    Arm, Body, Head
    //}

    public JointType jointType;

    public bool connected;

    private string targetTag = "Joint";

    // 存储当前碰撞的对象集合
    GameObject jointObject;

    // 当有物体进入碰撞器时调用
    void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞物体的标签
        if (collision.gameObject.CompareTag(targetTag))
        {
            jointObject = collision.gameObject;
        }
    }

    // 当物体离开碰撞器时调用
    void OnCollisionExit(Collision collision)
    {
        // 检查离开的物体标签
        if (collision.gameObject.CompareTag(targetTag))
        {
            jointObject = null;
        }
    }

    // 返回当前是否有任何指定标签的物体在碰撞
    public bool IsCollidingWithJoint()
    {
        return jointObject != null;
    }

    public JointObject getCollidingJoint()
    {
        if (IsCollidingWithJoint())
        {
            return jointObject.GetComponent<JointObject>();
        }
        return null;
    }
}
