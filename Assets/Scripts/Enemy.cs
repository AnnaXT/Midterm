using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public Image timerBar;
    public LayerMask whatIsBullet;
    Transform player;
    Animator _animator;
    Rigidbody2D _rigidbody;

    bool hit = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Move());
    }

    private void Update()
    {
        if(player.position.x > transform.position.x && transform.localScale.x < 0 ||
           player.position.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        hit = false;

        for (int i = 0; i < enemies.Length; ++i){
            hit = Physics2D.OverlapCircle(enemies[i].transform.position, 0.2f, whatIsBullet);
            if (hit) {
                timerBar.GetComponent<Timer>().changeTime(100f * Time.deltaTime);
                Destroy(enemies[i], .15f);
                hit = false;
            }

        }

        //hit = Physics2D.OverlapCircle(GameObject.FindGameObjectWithTag("Enemy").transform.position, 0.2f, whatIsBullet);

        //if (hit) {
        //    timerBar.GetComponent<Timer>().changeTime(100f * Time.deltaTime);
        //    Destroy(gameObject, .15f);
        //}

    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            _rigidbody.AddForce(new Vector2(transform.localScale.x * 100, 100));
        }
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     print("sp");
    //     if(other.CompareTag("Bullet"))
    //     {
    //         print("hit");
    //         timerBar.GetComponent<Timer>().changeTime(300f);
    //         //Instantiate(explosion, transform.position,Quaternion.identity);
    //         Destroy(other.gameObject);
    //         //_animator.SetTrigger("Die");
    //         Destroy(gameObject, .15f);
    //     }
    // }

}
