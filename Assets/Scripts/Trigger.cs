using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string tagName = "Player";
    public UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;
    //GameManager _gameManager; 

    void Start()
    {
        //_gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        print("Enter1");
        
        if(other.gameObject.CompareTag(tagName)){
            //other.GetComponent<PlayerHealth>().ChangeLifeVal(1);
            //_gameManager.UpdateLives(1);
            print("Enter");
            OnTriggerEnterEvent?.Invoke();
            print("Entered");
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag(tagName)){
            OnTriggerExitEvent?.Invoke();
        }
    }
}
