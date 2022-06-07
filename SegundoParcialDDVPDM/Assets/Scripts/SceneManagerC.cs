using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerC : MonoBehaviour
{
   
    void Start()
    {
        Time.timeScale = 1f;
    }

    
    void Update()
    {
       
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
       
        SceneManager.LoadScene(0);
        
    }
}
