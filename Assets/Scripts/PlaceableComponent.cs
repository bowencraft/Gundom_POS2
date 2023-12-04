using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableComponent : MonoBehaviour
{
    private string targetTag = "Component";
    public JointObject sourceJoint;

    // 存储当前碰撞的对象集合
    private HashSet<GameObject> collidingObjects = new HashSet<GameObject>();

    // 当有物体进入碰撞器时调用
    void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞物体的标签
        if (collision.gameObject.CompareTag(targetTag))
        {
            collidingObjects.Add(collision.gameObject);
        }
    }

    // 当物体离开碰撞器时调用
    void OnCollisionExit(Collision collision)
    {
        // 检查离开的物体标签
        if (collision.gameObject.CompareTag(targetTag))
        {
            collidingObjects.Remove(collision.gameObject);
        }
    }

    // 返回当前是否有任何指定标签的物体在碰撞
    public bool IsCollidingWithComponents()
    {
        return collidingObjects.Count > 0;
    }
}
