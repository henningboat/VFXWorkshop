using System;
using DG.Tweening;
using UnityEngine;

public class Player : Singleton<Player>
{
    public float _moveSpeed=3;
    public int lives = 3;
   
    Rigidbody _rigidbody;
    Renderer _renderer;

    float _stunTime = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer=GetComponentInChildren<Renderer>();
    }

    void FixedUpdate()
    {
        _stunTime-=Time.deltaTime;

        if (_stunTime <= 0)
        {
            var keyboardInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            var cameraTransform = CameraController.Instance.transform;
            
            //rotate keyboard input by the Camera's rotation around the up axis
            keyboardInput = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * keyboardInput;
            
            if (keyboardInput.magnitude > 0.01f)
            {
                transform.LookAt(transform.position + keyboardInput);
                _rigidbody.linearVelocity += keyboardInput * (_moveSpeed * Time.deltaTime);
            }
        }
    }

    public void ApplyDamage(Vector3 bounceImpulse)
    {
        _rigidbody.linearVelocity += bounceImpulse;
        lives--;
        _stunTime = 1;

        foreach (var material in _renderer.materials)
        {
            var neutralColor = material.color;
            material.color = Color.red;
            material.DOColor(neutralColor, 0.25f).SetEase( Ease.OutQuart).SetLoops(4);
        }
    }
}