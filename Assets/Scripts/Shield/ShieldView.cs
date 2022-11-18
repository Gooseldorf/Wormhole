using System;
using Interfaces;
using UnityEngine;
using Views;


public sealed class ShieldView : MonoBehaviour, IDamagable
{
    [SerializeField] private ParticleSystem _impactParticles;
    public MeshRenderer ShieldRenderer { get; private set; }
    public ParticleSystem ImpactParticles => _impactParticles;
    
    public event Action <float> OnDamage;

    private void Awake()
    {
        ShieldRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AsteroidView asteroid))
        {
            ReceiveDamage(asteroid.Damage);
            asteroid.ReceiveDamage(asteroid.CurrentHealth + 1);
        }
    }

    public void ReceiveDamage(float damage)
    {
        OnDamage?.Invoke(damage);
    }
}
