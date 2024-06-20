using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent onKeyCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        onKeyCollected.Invoke();
        Destroy(gameObject);
    }
}
