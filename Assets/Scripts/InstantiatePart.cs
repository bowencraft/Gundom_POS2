using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiatePart : MonoBehaviour, IPointerClickHandler
{
    //public GameObject prefabPart;

    private MoveAndRotatePart prefabHandle;
    // Start is called before the first frame update
    void Start()
    {
        prefabHandle = GameObject.Find("ControlManager").GetComponent<MoveAndRotatePart>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        prefabHandle.CheckForClick();
    }
}
