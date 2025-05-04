using System;
using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    SphereCollider _parentSphereCollider;
    Rigidbody _parentRigidbody;

    void Start()
    {
        _parentSphereCollider = GetComponentInParent<SphereCollider>();
        _parentRigidbody = GetComponentInParent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (_parentRigidbody.linearVelocity.magnitude > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_parentRigidbody.linearVelocity.x, 0,
                _parentRigidbody.linearVelocity.z));
        }
    }
}
