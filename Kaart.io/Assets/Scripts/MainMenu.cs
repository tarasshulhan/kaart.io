using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CountriesEasy()
    {
        SceneManager.LoadScene(1);        
    }

    public void CountriesHard()
    {
        SceneManager.LoadScene(2);        
    }

    public void Cities()
    {
        SceneManager.LoadScene(3);
    }

    public void Rivers()
    {
        SceneManager.LoadScene(4);
    }    

    public void Geology()
    {
        SceneManager.LoadScene(5);
    }

    public void Landmarks()
    {
        SceneManager.LoadScene(6);
    }

    public void Americas()
    {
        SceneManager.LoadScene(7);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
