using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    public Image timerBar;
    public float maxTime = 20f;
    float timeLeft;
    private bool snoozed = false;

    void Start()
    {
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0 && !snoozed){
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else if (timeLeft <= 0){
            SceneManager.LoadScene("Lose");
        }
        
    }

    public void changeTime(float amount){
        timeLeft += amount;
    }

    public void snooze(){
        snoozed = true;
    }
}
