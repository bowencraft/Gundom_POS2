using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private GameObject currentPrefab;
    private PlaceableComponent currentComponent;

    public GameObject jointPrefab;

    public LayerMask layerMask; // 指定的层
    public string targetLayerName; // 放置后设置的层名称

    private bool isPlacing = false;

    private Vector3 targetPosition;

    public GameObject testPrefab;
    public float targetSpeed;

    private Camera cam;

    private GameObject currentJointObject;
    private JointObject currentJoint;

    public Material jointConnectedMaterial;
    public Material colliderOverlapMaterial;

    //private Material[] 

    void Start()
    {
        cam = Camera.main;
        currentJointObject = Instantiate(jointPrefab);
        currentJoint = currentJointObject.GetComponent<JointObject>();
        currentJointObject.SetActive(false);
    }

    void Update()
    {
        if (isPlacing)
        {
            if (currentPrefab == null) Debug.LogError("CurrentPrefab is null in placing mode");

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Move target position with Raycast
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && !Input.GetKey(KeyCode.LeftShift))
            {
                targetPosition = hit.point;
            }

            currentJointObject.transform.position = targetPosition;

            JointObject rotationJoint = TryAbsorptJoint() ? currentJoint.getCollidingJoint() : currentJoint;
            currentPrefab.transform.rotation = Quaternion.Lerp(currentPrefab.transform.rotation, rotationJoint.transform.rotation, targetSpeed * Time.deltaTime);

            currentPrefab.transform.position = Vector3.Lerp(currentPrefab.transform.position, targetPosition, targetSpeed * Time.deltaTime);

            // Input Manager

            if (Input.GetMouseButtonDown(0))
            {
                ConfirmPlacement();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                // 锁定鼠标在屏幕中央
                //Cursor.lockState = CursorLockMode.Loc;
                // 可以选择隐藏鼠标指针
                Cursor.visible = false;

                // 计算从物体位置到鼠标位置的方向
                rotationJoint.transform.LookAt(GetMousePositionAtScreen());
            } else
            {

                Cursor.visible = true;
            }

            if (Input.GetKey(KeyCode.W))
                rotationJoint.transform.Rotate(Vector3.right, targetSpeed * Time.deltaTime * 4);
            if (Input.GetKey(KeyCode.S))
                rotationJoint.transform.Rotate(Vector3.left, targetSpeed * Time.deltaTime * 4);
            if (Input.GetKey(KeyCode.Q))
                rotationJoint.transform.Rotate(Vector3.down, targetSpeed * Time.deltaTime * 4);
            if (Input.GetKey(KeyCode.E))
                rotationJoint.transform.Rotate(Vector3.up, targetSpeed * Time.deltaTime * 4);
            if (Input.GetKey(KeyCode.A))
                rotationJoint.transform.Rotate(Vector3.back, targetSpeed * Time.deltaTime * 4);
            if (Input.GetKey(KeyCode.D))
                rotationJoint.transform.Rotate(Vector3.forward, targetSpeed * Time.deltaTime * 4);

            if (Input.GetKeyDown(KeyCode.Escape))
                ExitPlacementMode();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPlacing) EnterPlacementMode(testPrefab);
        }

    }

    Vector3 GetMousePositionAtScreen()
    {

        Vector3 mouseScreenPosition = Input.mousePosition;

        // 设置鼠标在游戏世界中的深度。例如，你可以使用摄像机到物体的距离
        mouseScreenPosition.z = - cam.transform.position.z + transform.position.z;

        // 将鼠标屏幕位置转换为游戏世界位置
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mouseScreenPosition);
        return mouseWorldPosition;
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

    public void EnterPlacementMode(GameObject prefab)
    {
        if (!isPlacing)
        {
            currentJointObject.SetActive(true);

            currentPrefab = Instantiate(prefab, GetMousePositionAtScreen(), Quaternion.identity);
            currentComponent = currentPrefab.GetComponent<PlaceableComponent>();

            currentJoint.jointType = currentComponent.sourceJoint.jointType;
            if (currentComponent == null) Debug.LogError(currentPrefab + "don't have PlaceableComponent!");

            isPlacing = true;
        }

    }

    public void ExitPlacementMode()
    {
        currentJointObject.SetActive(false);
        currentComponent = null;

        if (currentPrefab != null) Destroy(currentPrefab);
        isPlacing = false;
    }

    public bool ConfirmPlacement()
    {
        if (TryAbsorptJoint() && !currentComponent.IsCollidingWithComponents())
        {
            JointObject joint = currentJoint.getCollidingJoint();
            //currentPrefab.transform.Rotate(joint.transform.rotation.eulerAngles - currentPrefab.transform.rotation.eulerAngles, 10f * Time.deltaTime);
            currentPrefab.transform.rotation = joint.transform.rotation;
            currentPrefab.transform.parent = joint.transform;

            SetLayerRecursively(currentPrefab, 6);
            currentComponent.sourceJoint.connected = true;

            joint.connected = true;

            currentPrefab = null;

            ExitPlacementMode();
            return true;
        }
        return false;
    }


    public bool TryAbsorptJoint()
    {
        if (isPlacing)
        {
            //JointObject sourceJoint = currentComponent.sourceJoint;
            if (currentJoint.IsCollidingWithJoint())
            {
                //Debug.Log("Collided!");
                JointObject goalJoint = currentJoint.getCollidingJoint();
                if (!goalJoint.connected && goalJoint.jointType == currentJoint.jointType)
                {
                    currentPrefab.transform.rotation = goalJoint.transform.rotation;
                    //currentPrefab.transform.Rotate(goalJoint.transform.rotation.eulerAngles - currentPrefab.transform.rotation.eulerAngles, 100f * Time.deltaTime);
                    targetPosition = goalJoint.transform.position;
                    return true;
                }

            }
        } else
        {
            Debug.LogWarning("Operation while is not in placement mode!");
        }
        return false;

    }
}