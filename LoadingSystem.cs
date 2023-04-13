using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadingSystem
{
    static string loadingSceneName = "Loading";

    static string sceneName;
    static LoadHandler loadHandler;

    public static void Initialize()
    {
        if (loadHandler != null)
        {
            Debug.LogWarning("LoadingSystem already initialized");
            return;
        }
        GameObject go = Resources.Load<GameObject>("Loading_Canvas");
        
        if (go == null)
        {
            Debug.LogError("Loading_Canvas not found");
            SceneManager.LoadScene(sceneName);
            return;
        }

         loadHandler = GameObject.Instantiate(go).GetComponent<LoadHandler>();
    }

    public static void LoadScene(string sceneName)
    {
        if(!loadHandler)
            Initialize();

        loadHandler.Load(sceneName);
    }

}

