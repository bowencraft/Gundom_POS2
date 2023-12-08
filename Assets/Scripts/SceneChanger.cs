using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    Scene currentScene;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void ChangeScene()
    {
        if(currentScene.name == "GundamScene")
        {
            SceneManager.LoadScene("Showcase");
        }
        else
        {
            SceneManager.LoadScene("GundamScene");
        }
        
    }
}
