using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public void LoadGame()
   // {
     //   SceneManager.LoadScene("main");
    //}

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}

