using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public bool isOpen = false;
    public int nextScene;

    public void OpenGate()
    {
        if (!isOpen)
        {
            Debug.Log("Door is now open");
            isOpen = true;     
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOpen)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
