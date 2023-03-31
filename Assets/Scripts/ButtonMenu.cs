using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("Level 1");
    }

    public void PlayGameWithoutTutorial(){
        SceneManager.LoadScene("level 4");
    }

    public void LoadHelp() {
        SceneManager.LoadScene("Help");
    }

    public void Quit() 
    {
        SceneManager.LoadScene("start");
    }

    public void QuitGame() {
        {
            #if !UNITY_WEBGL
                Application.Quit();
            #endif
        
        }
    }

}