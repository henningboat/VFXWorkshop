using System;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float boundBackStrength = 4;

    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        player.ApplyDamage(transform.forward * boundBackStrength);
    }
}
