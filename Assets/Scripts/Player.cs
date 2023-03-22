using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 8;
    public int jumpForce = 888;

    public LayerMask whatIsGround;
    public Transform feet;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    bool grounded = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed; //
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        float xScale = transform.localScale.x;
        if((xSpeed < 0 && xScale > 0) || (xSpeed > 0 && xScale < 1))
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        _animator.SetFloat("Speed", xSpeed);
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, 0.2f, whatIsGround);
        //_animator.SetBool("Grounded", grounded);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
