using System;
using UnityEngine;


public sealed class LaserHitView : MonoBehaviour
{
    private Rigidbody _rb;
    private float _lifetime;
    private float _timer;

    public Rigidbody Rb => _rb;
    public float Lifetime
    {
        set => _lifetime = value;
    }
    
    public event Action<LaserHitView> EndOfLifetime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _lifetime)
        {
            EndOfLifetime?.Invoke(this);
        }
    }
}
