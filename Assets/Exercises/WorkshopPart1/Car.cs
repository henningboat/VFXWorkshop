using System;
using UnityEngine;

public class Car : MonoBehaviour
{
     float speed=10;
     float speedBoost=70;
     
     public Gradient colorTintGradient;
     public AnimationCurve boostScale = AnimationCurve.Constant(0, 1, 0);
     public float boostJumpHeight = 0;
    
    Rigidbody _rigidbody;
    Renderer _mainRenderer;
    bool _isBoosting;
    float _boostTimer;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearVelocity = speed * transform.forward*0.5f;
        _mainRenderer = GetComponentInChildren<Renderer>();
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(speed * transform.forward, ForceMode.Acceleration);

        if (_isBoosting)
        {
            _boostTimer += Time.deltaTime;
            foreach (var mat in _mainRenderer.materials)
            {
                mat.color = colorTintGradient.Evaluate(_boostTimer);
            }
            _mainRenderer.transform.localScale = Vector3.one*(1+boostScale.Evaluate(_boostTimer));
            _rigidbody.AddForce(Vector3.up * boostJumpHeight);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            _isBoosting = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            _rigidbody.AddForce(transform.forward * speedBoost, ForceMode.Acceleration);
        }
    }
}
