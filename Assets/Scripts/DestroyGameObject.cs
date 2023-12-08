using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject destroyModel;
    void Start()
    {
        destroyModel = GameObject.Find("=== Robot ===").gameObject;
    }

    public void _Destroy()
    {
        Destroy(destroyModel);
    }
}
