using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovementUpward : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCam();   
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    void MoveCam()
    {
        if (transform.position.y < 30)
        {
            transform.Translate(new Vector2(0, speed));
        }
    }
}
