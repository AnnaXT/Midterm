using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 8;
    public int jumpForce = 888;
    public int flyForce = 111;
    public int bulletForce = 500;

    public LayerMask whatIsGround;
    public Transform feet;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public AudioClip shootSnd;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private AudioSource _audiosource;

    bool grounded = false;
    bool pwrUp = false;

    void set_pwrUp(bool stat){ pwrUp = stat; }
    bool get_pwrUp(){ return pwrUp; }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audiosource = GetComponent<AudioSource>();
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

        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, 0.2f, whatIsGround);
        pwrUp = get_pwrUp();

        _animator.SetBool("Grounded", grounded);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
        else if (Input.GetButtonDown("Jump") && pwrUp)
        {
            StartCoroutine(Timer());
            _rigidbody.AddForce(new Vector2(0, flyForce));
        }

        if(Input.GetButtonDown("Fire1"))
        {
            _animator.Play("PlayerAttack");
            _audiosource.PlayOneShot(shootSnd);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            
            if(transform.localScale.x > 0)
            {
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletForce, 0));
            }
            else 
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce, 0));
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("PowerUp"))
        {
            print(0);
            set_pwrUp(true);
        }
    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(5);
        set_pwrUp(false);
    }
}
