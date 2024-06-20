using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Banana : MonoBehaviour
{
    CanvasManager cm;

    void Start()
    {
        cm = GameObject.FindWithTag("Canvas").GetComponent<CanvasManager>();
    }
    public void Collect()
    {
        cm.AddBanana();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}
