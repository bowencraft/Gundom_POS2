using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiatePart : MonoBehaviour
{
    public GameObject prefabPart;
    private MoveAndRotatePart prefabHandle;

    void Start()
    {
        prefabHandle = GameObject.Find("ControlManager").GetComponent<MoveAndRotatePart>();
    }

    //mouse detecting 
    void OnMouseDown()
    {
        prefabHandle.ChangePrefabPos = true;
        prefabHandle.CheckForClick(prefabPart);
    }


}
