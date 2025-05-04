using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Bullet : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _speed = 20f;
    [SerializeField] ParticleSystem _impactParticlePrefab;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = transform.forward* _speed;
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        Instantiate(_impactParticlePrefab, transform.position, Quaternion.LookRotation(-transform.forward));
    }
}
