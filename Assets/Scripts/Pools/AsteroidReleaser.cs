using UnityEngine;
using Views;
using Zenject;

public class AsteroidReleaser : MonoBehaviour
{
    private AsteroidPool _asteroidPool;

    [Inject]
    private void Construct(AsteroidPool pool)
    {
        _asteroidPool = pool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<AsteroidView>(out AsteroidView asteroidView))
        {
            _asteroidPool.AsteroidsPool.Release(other.gameObject);
        }
    }
}
