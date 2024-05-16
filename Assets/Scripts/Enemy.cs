using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public float minX;
    public float maxX;


    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }
    protected virtual void Update()
    {
        // Call the Move method in the Update to move the enemy
        Move();
        Flip();
    }

    protected virtual void Move()
    {
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            speed *= -1;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    protected virtual void Flip()
    {
        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        }
        if (rb.velocity.x < 0)
        {
            sr.flipX = false;
        }
    }

    
}
