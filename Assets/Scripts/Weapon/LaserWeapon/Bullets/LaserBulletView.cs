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

    public event Action<GameObject> BulletCollision;
    public event Action<GameObject> EndOfLifetime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        _timer = 0;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out IDamagable damagable);
        damagable.ReceiveDamage(_damage);
        BulletCollision?.Invoke(gameObject);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _lifetime)
        {
            EndOfLifetime?.Invoke(gameObject);
        }
    }
}
