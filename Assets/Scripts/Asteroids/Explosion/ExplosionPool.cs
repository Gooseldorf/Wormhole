using Data;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;


namespace Pools
{
    public sealed class ExplosionPool: MonoBehaviour
    {
        private ExplosionData _explosionData;
        private ObjectPool<ExplosionView> _explosionPool;

        public ObjectPool<ExplosionView> Pool => _explosionPool;

        [Inject]
        private void Construct(ExplosionData data)
        {
            _explosionData = data;
        }
        private void Start()
        {
            _explosionPool = new ObjectPool<ExplosionView>(CreateExplosion, GetExplosion, ReleaseExplosion,
                explosion => Destroy(explosion.gameObject), true,
                _explosionData.ExplosionPoolCapacity, _explosionData.ExplosionMaxPoolCapacity);
        }

        private ExplosionView CreateExplosion()
        {
            GameObject explosion = Instantiate(_explosionData.ExplosionPrefab);
            explosion.TryGetComponent(out ExplosionView view);
            view.Lifetime = _explosionData.LifeTime;
            view.EndOfLifetime += delegate(ExplosionView explosionView) {_explosionPool.Release(explosionView);  };
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