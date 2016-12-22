using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void GameStart()
    {
        SceneManager.LoadSceneAsync("Room", LoadSceneMode.Single);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
