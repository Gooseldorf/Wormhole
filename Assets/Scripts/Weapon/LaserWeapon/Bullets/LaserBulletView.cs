using System;
using Interfaces;
using UnityEngine;


public sealed class LaserBulletView : MonoBehaviour
{
    private Rigidbody _rb;
    private float _lifetime;
    private float _timer;
    private float _damage;
    public Rigidbody Rb => _rb;
    public float Lifetime
    {
        set => _lifetime = value;
    }

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public event Action<GameObject> ReleaseRequest;
    public event Action<Vector3,Vector3> OnLaserBulletCollision;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        _timer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.TryGetComponent(out IDamagable damagable);
        collision.collider.TryGetComponent(out Rigidbody rb);
        damagable.ReceiveDamage(_damage);
        ReleaseRequest?.Invoke(gameObject);
        OnLaserBulletCollision?.Invoke(transform.position, rb.velocity);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out IDamagable damagable);
        damagable.ReceiveDamage(_damage);
        BulletCollision?.Invoke(gameObject);
    }*/

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _lifetime)
        {
            ReleaseRequest?.Invoke(gameObject);
        }
    }
}
