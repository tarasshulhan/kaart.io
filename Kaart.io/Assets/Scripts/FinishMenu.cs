using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public void Back2Menu()
    {
        SceneManager.LoadScene(0);        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
