using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animation anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //print("entered");
            anim.Play("Walking");
        }

        //if (Input.GetKeyDown(KeyCode.A)){
        //    print("Entered");
        //    anim.Play("Walking");
        //}
        
    }
}
