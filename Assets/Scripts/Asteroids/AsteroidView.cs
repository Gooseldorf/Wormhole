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

        public Rigidbody Rb => _rb;
        
        public Action<AsteroidView> ReleaseRequest;
        public static event Action<AsteroidView> OnAsteroidDestruction;

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
            }
        }

        private async void AsteroidExplosion()
        {
            OnAsteroidDestruction?.Invoke(this);
            await Task.Delay(_asteroidData.AwaitBeforeRelease);
            ReleaseRequest?.Invoke(this);
        }
    }
}
