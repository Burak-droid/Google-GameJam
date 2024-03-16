using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shoot
{
     public class Enemy : MonoBehaviour
{
    AudioSource audio;
    public GameObject pointA;

    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;

    private Transform currentPoint;
    public int health = 100;
    public float speed;
    public GameObject deathEffect;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        //anim.SetBool("isrunning", true);
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }

    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }

}

}
