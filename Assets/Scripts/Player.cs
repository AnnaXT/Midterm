using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image timerBar;

    public int speed = 8;
    public int jumpForce = 888;
    public int flyForce = 111;
    public int bulletForce = 500;

    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;
    public Transform feet;
    public Transform front;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public AudioClip shootSnd;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private AudioSource _audiosource;

    bool grounded = false;
    bool pwrUp = false;
    bool hit = false;

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
        hit = Physics2D.OverlapCircle(front.position, 0.2f, whatIsEnemy);

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

        if (hit) {
            timerBar.GetComponent<Timer>().changeTime(-3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        print("Entered");
        if (other.CompareTag("PowerUp"))
        {
            print(0);
            set_pwrUp(true);
        }
        // else if (other.CompareTag("Enemy")){
        //     print("enemy");
        //     timerBar.GetComponent<Timer>().changeTime(-3f);
        // }
        else if (other.CompareTag("Snooze")){
            print("snooze");
            timerBar.GetComponent<Timer>().snooze();
        }

        else if (other.CompareTag("Heart")){
            print("heart");
            timerBar.GetComponent<Timer>().changeTime(3f);
        }

    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(5);
        set_pwrUp(false);
    }
}
