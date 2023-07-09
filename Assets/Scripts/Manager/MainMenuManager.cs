using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Act1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void LoadMenuSequence()
    {
        Invoke("LoadGame", 2.3f);
    }
    
}
