using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad robot;
    public bool refresh = false;

    void Awake()
    {
        if (robot == null)
        {
            robot = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            
        }
    }
    void LateUpdate()
    {
        if(!refresh && SceneManager.GetActiveScene().name != "Showcase")
        {
            ConfirmRefresh();
        }

        if (refresh && SceneManager.GetActiveScene().name == "Showcase")
        {
            Invoke("Refresh", 0);
            refresh = false;
        }
    }
    public void Refresh()
    {
        // restart
        print("restart");
        if (SceneManager.GetActiveScene().name != "Showcase")
        {
            Destroy(gameObject);
            Instantiate(gameObject);
        }
    }

    public void ConfirmRefresh()
    {
        refresh = true;
    }



}
