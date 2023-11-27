using UnityEngine;

public class MoveAndRotatePrefab : MonoBehaviour
{
    public GameObject prefab; // 指定的Prefab
    private GameObject currentPrefab;
    private Camera cam;
    public LayerMask layerMask; // 指定的层
    public string targetLayerName; // 放置后设置的层名称

    void Start()
    {
        cam = Camera.main;
        CreateNewPrefab();
    }

    void Update()
    {
        MovePrefabWithRaycast();
        RotatePrefab();
        CheckForClick();
    }

    void MovePrefabWithRaycast()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // 将物品移动到射线击中的位置
            currentPrefab.transform.position = hit.point;
        }
    }

    void RotatePrefab()
    {
        if (Input.GetKey(KeyCode.W))
            currentPrefab.transform.Rotate(Vector3.right, Time.deltaTime * 100);
        if (Input.GetKey(KeyCode.S))
            currentPrefab.transform.Rotate(Vector3.left, Time.deltaTime * 100);
        if (Input.GetKey(KeyCode.A))
            currentPrefab.transform.Rotate(Vector3.down, Time.deltaTime * 100);
        if (Input.GetKey(KeyCode.D))
            currentPrefab.transform.Rotate(Vector3.up, Time.deltaTime * 100);
        if (Input.GetKey(KeyCode.Q))
            currentPrefab.transform.Rotate(Vector3.back, Time.deltaTime * 100);
        if (Input.GetKey(KeyCode.E))
            currentPrefab.transform.Rotate(Vector3.forward, Time.deltaTime * 100);
    }

    void CheckForClick()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键
        {
            SetLayerRecursively(currentPrefab, LayerMask.NameToLayer(targetLayerName));
            CreateNewPrefab();
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null)
            return;

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child == null)
                continue;
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    void CreateNewPrefab()
    {
        currentPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
}
