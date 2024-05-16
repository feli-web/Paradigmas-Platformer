using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public float camSpeed;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Vector2 playerPosition = other.transform.position;
            Vector2 colliderPosition = transform.position;

            if (playerPosition.x < colliderPosition.x)
            {
                if (other.transform.position.x < 10 && other != null)
                {
                    animator.Play("Displacement2-1");
                }

                if (other.transform.position.x < 29 && other.transform.position.x > 10 && other != null)
                {
                    animator.Play("Displacement3-2");
                }
            }
            if (playerPosition.x > colliderPosition.x)
            {
                if (other.transform.position.x > 9 && other.transform.position.x < 27 && other != null)
                {
                    animator.Play("Displacement1-2");
                }
                if (other.transform.position.x > 27 && other != null)
                {
                    animator.Play("Displacement2-3");
                }
            }
        }
    }
}
