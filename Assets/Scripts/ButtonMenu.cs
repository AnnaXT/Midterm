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

    public void level2() 
    {
        SceneManager.LoadScene("Level 2");
    }

    public void level3() 
    {
        SceneManager.LoadScene("Level 3");
    }

    public void level4() 
    {
        SceneManager.LoadScene("Level 4");
    }

    public void level5() 
    {
        SceneManager.LoadScene("Level 5");
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

    public void QuitGame()
    {
        Application.Quit();
    }

}