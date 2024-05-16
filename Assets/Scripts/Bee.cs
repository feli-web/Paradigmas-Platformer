using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bee : Enemy
{
    protected override void Move()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerMove>().isKilling == true)
            {
                health--;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
