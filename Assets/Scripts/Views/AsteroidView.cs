using UnityEngine;
using Random = UnityEngine.Random;


namespace Views
{
    public class AsteroidView : MonoBehaviour
    {
        [SerializeField] private float _maxTumble;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _rb.angularVelocity = Random.insideUnitSphere * Random.Range(0.5f, _maxTumble);
            _rb.velocity = Vector3.back * Random.Range(10f, 50f);
        }

        private void OnDisable()
        {
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }
    }
}
