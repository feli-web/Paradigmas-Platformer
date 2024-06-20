using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        if (player != null)
        {
            ApplyEffect(player);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(PlayerMove player);
}
