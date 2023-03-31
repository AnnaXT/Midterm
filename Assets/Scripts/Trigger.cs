using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string tagName = "Player";
    public Vector3 position = new Vector3(0,0,0);
    public UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;
    public GameObject portalPrefab;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag(tagName)){
            OnTriggerEnterEvent?.Invoke();
            Destroy(gameObject);
            if (gameObject.tag == "Snooze"){
                Instantiate(portalPrefab, position, Quaternion.identity);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag(tagName)){
            OnTriggerExitEvent?.Invoke();
        }
    }
}
