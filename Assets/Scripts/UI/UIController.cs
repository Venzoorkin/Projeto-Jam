using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Scene Temp");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
