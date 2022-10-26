using Data;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Views
{
    public class AsteroidView : MonoBehaviour
    {
        [SerializeField] private float _maxTumble;
        [SerializeField] private AsteroidData _asteroidData;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            /*transform.localScale.Set(1,1,1);
            transform.localScale *= Random.Range(_asteroidData.MinScale, _asteroidData.MaxScale);*/
            _rb.angularVelocity = Random.insideUnitSphere * Random.Range(0.5f, _maxTumble);
            _rb.velocity = Vector3.back * Random.Range(_asteroidData.MinSpeed, _asteroidData.MaxSpeed);
        }

        private void OnDisable()
        {
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }
    }
}
