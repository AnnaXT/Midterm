using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string tagName = "Player";
    public UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag(tagName)){
            OnTriggerEnterEvent?.Invoke();
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag(tagName)){
            OnTriggerExitEvent?.Invoke();
        }
    }
}
