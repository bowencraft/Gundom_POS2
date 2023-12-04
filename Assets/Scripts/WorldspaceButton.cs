using UnityEngine;
using UnityEngine.Events;

public class WorldspaceButton : MonoBehaviour
{
    public LayerMask layerMask = 5;

    public UnityEvent clickEvent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.gameObject == gameObject) // 检测是否点击了这个按钮
                {
                    // 这里实现按钮点击后的逻辑
                    clickEvent.Invoke();
                }
            }
        }
    }
}
