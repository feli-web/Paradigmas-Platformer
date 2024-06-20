using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUp
{
    public float duration;
    protected override void ApplyEffect(PlayerMove player)
    {
        player.StartCoroutine(player.Invincible(duration));
    }
}
