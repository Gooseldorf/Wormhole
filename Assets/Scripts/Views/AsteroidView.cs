using System;
using System.Threading.Tasks;
using Data;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Views
{
    public class AsteroidView : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _maxTumble;
        [SerializeField] private AsteroidData _asteroidData;
        private Rigidbody _rb;

        public Action<AsteroidView> ReleaseRequest;

        public float CurrentHealth { get; set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _rb.angularVelocity = Random.insideUnitSphere * Random.Range(0.5f, _maxTumble);
            _rb.velocity = Vector3.back * Random.Range(_asteroidData.MinSpeed, _asteroidData.MaxSpeed);
        }

        private void OnDisable()
        {
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }

        public void ReceiveDamage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0)
            {
                AsteroidExplosion();
                /*GameObject explosion = Instantiate(_asteroidData.ExplosionPrefab, transform.position, transform.rotation);
                explosion.TryGetComponent(out Rigidbody rb);
                rb.velocity = _rb.velocity;
                ReleaseRequest?.Invoke(this);*/
            }
        }

        private async void AsteroidExplosion()
        {
            GameObject explosion = Instantiate(_asteroidData.ExplosionPrefab, transform.position, transform.rotation);
            explosion.TryGetComponent(out Rigidbody rb);
            rb.velocity = _rb.velocity;
            await Task.Delay(800);
            ReleaseRequest?.Invoke(this);
        }
    }
}
