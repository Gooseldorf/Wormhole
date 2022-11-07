using Data;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;


namespace Pools
{
    public class ExplosionPool: MonoBehaviour
    {
        private AsteroidData _asteroidData;
        private ObjectPool<ExplosionView> _explosionPool;

        public ObjectPool<ExplosionView> Pool => _explosionPool;

        [Inject]
        private void Construct(AsteroidData data)
        {
            _asteroidData = data;
        }
        private void Start()
        {
            _explosionPool = new ObjectPool<ExplosionView>(CreateExplosion, GetExplosion, ReleaseExplosion,
                explosion => Destroy(explosion.gameObject), true,
                _asteroidData.ExplosionPoolCapacity, _asteroidData.ExplosionMaxPoolCapacity);
        }

        private ExplosionView CreateExplosion()
        {
            GameObject explosion = Instantiate(_asteroidData.ExplosionPrefab);
            explosion.TryGetComponent(out ExplosionView view);
            return view;
        }

        private void GetExplosion(ExplosionView obj)
        {
            obj.gameObject.SetActive(true);
        }

        private void ReleaseExplosion(ExplosionView obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}