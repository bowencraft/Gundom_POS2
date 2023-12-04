using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiatePart : MonoBehaviour
{
    public GameObject prefabPart;
    private PlacementManager prefabHandle;

    void Start()
    {
        prefabHandle = GameObject.Find("ControlManager").GetComponent<PlacementManager>();
        Instantiate(prefabPart, transform);
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void StartPlacement()
    {
        prefabHandle.EnterPlacementMode(prefabPart);
    }

    ////mouse detecting 
    //void OnMouseDown()
    //{
    //    prefabHandle.ChangePrefabPos = true;
    //    prefabHandle.CheckForClick(prefabPart);
    //}


}
