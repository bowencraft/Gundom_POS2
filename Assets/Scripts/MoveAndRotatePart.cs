using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotatePart : MonoBehaviour
{
    //public GameObject prefab; // 指定的Prefab
    private GameObject currentPrefab;
    private Camera cam;
    public LayerMask layerMask; // 指定的层
    public string targetLayerName; // 放置后设置的层名称

    public bool ChangePrefabPos = false;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        MovePrefabWithRaycast();
        RotatePrefab();

        if (Input.GetMouseButtonDown(0))
        {
            CheckForClick();
        }
    }

    void MovePrefabWithRaycast()
    {
        //prefab following mouse
        if (ChangePrefabPos)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // 将物品移动到射线击中的位置
                currentPrefab.transform.position = hit.point;
            }
        }
    }

    void RotatePrefab()
    {
        //before the prefab is attached
        if (ChangePrefabPos)
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
    }

    public void CheckForClick(GameObject prefab)
    {
        //only trigger when click has been clicked from the InstantiatePart Script
        SetLayerRecursively(currentPrefab, LayerMask.NameToLayer(targetLayerName));
        CreateNewPrefab(prefab);
    }

    public void CheckForClick()
    {
        //only trigger when click has been clicked from the InstantiatePart Script
        SetLayerRecursively(currentPrefab, LayerMask.NameToLayer(targetLayerName));
        currentPrefab = null;
        ChangePrefabPos = false;
        //CreateNewPrefab(prefab);
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

    void CreateNewPrefab(GameObject prefab)
    {
        currentPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
}
