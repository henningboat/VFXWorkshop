using System;
using DG.Tweening;
using UnityEngine;
using Object = UnityEngine.Object;

public class Player : Singleton<Player>
{
    public float _moveSpeed=3;
    public int lives = 3;
   
    Rigidbody _rigidbody;
    Renderer _renderer;

    float _stunTime = 0;

    public ParticleSystem _particles;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer=GetComponentInChildren<Renderer>();
    }

    bool hadInput = false;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bulletPrefab, _gun.position, _gun.rotation);
        }
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
            
            
            var hasInput = keyboardInput.magnitude > 0.1f;
            
            if (keyboardInput.magnitude > 0.01f)
            {
                transform.LookAt(transform.position + keyboardInput);
                _rigidbody.linearVelocity += keyboardInput * (_moveSpeed * Time.deltaTime);
            }

            if (hadInput&&!hasInput)
            {
                    _particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
            if(hasInput&&!hadInput)
            {
                    _particles.Play();
                
            }

            hadInput = hasInput;

          
        }
    }

    public void ApplyDamage(Vector3 bounceImpulse)
    {
        if (_stunTime < 0)
        {
            foreach (var material in _renderer.materials)
            {
                var neutralColor = material.color;
                material.color = Color.red;
                material.DOColor(neutralColor, 0.20f).SetEase(Ease.OutQuart).SetLoops(4);
            }
        }
        
        _rigidbody.linearVelocity += bounceImpulse;
        lives--;
        _stunTime = 1;

    }
}