using System;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float boundBackStrength = 4;
    public ParticleSystem _damageParticles;

    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        player.ApplyDamage(transform.forward * boundBackStrength);

        Instantiate(_damageParticles.gameObject, other.contacts[0].point, Quaternion.LookRotation(-transform.forward));
    }
}
