using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void L1()
    {
        
        SceneManager.LoadScene(2);
    }

    public void L2()
    {
        
        SceneManager.LoadScene(3);
    }

    public void L3()
    {
       
        SceneManager.LoadScene(4);
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu()");
    }


}
