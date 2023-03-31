using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRendering : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void displayBeginning(){
        StartCoroutine(displayForLength(20f));
    }

    public void appear(){
        text.gameObject.SetActive(true);
    }

    public void remove(){
        text.gameObject.SetActive(false);
    }

    public void display(){
        StartCoroutine(displayForLength(3f));
    }


    private IEnumerator displayForLength(float sec){
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);
        text.gameObject.SetActive(false);
    }
}
