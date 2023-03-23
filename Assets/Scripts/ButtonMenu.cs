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
        SceneManager.LoadScene("HelpScene");
    }

    public void Quit() {
        SceneManager.LoadScene("Start Menu");
    }

}