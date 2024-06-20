using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bee : Enemy
{
    public GameObject player;
    private bool isMoving = false;

    protected override void Move()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isMoving)
        {
            StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        isMoving = true;

        
        while (Vector2.Distance(transform.position, new Vector2(transform.position.x, player.transform.position.y)) > 0.01f)
        {
            Vector2 targetPosition = new Vector2(transform.position.x, player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null; 
        }

        yield return new WaitForSeconds(1f);

        while (Vector2.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
            yield return null; 
        }

        isMoving = false;
    }
}