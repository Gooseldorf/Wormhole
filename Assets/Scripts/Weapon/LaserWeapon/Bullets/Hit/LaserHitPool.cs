using Data;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;


namespace Pools
{
    public sealed class LaserHitPool : MonoBehaviour
    {
        private LaserHitData _laserHitData;
        private ObjectPool<LaserHitView> _laserHitPool;

        public ObjectPool<LaserHitView> Pool => _laserHitPool;

        [Inject]
        private void Construct(LaserHitData data)
        {
            _laserHitData = data;
        }
        private void Start()
        {
            _laserHitPool = new ObjectPool<LaserHitView>(CreateExplosion, GetExplosion, ReleaseExplosion,
                explosion => Destroy(explosion.gameObject), true,
                _laserHitData.LaserHitPoolCapacity, _laserHitData.LaserHitMaxPoolCapacity);
        }

        private LaserHitView CreateExplosion()
        {
            GameObject explosion = Instantiate(_laserHitData.LaserHitPrefab);
            explosion.TryGetComponent(out LaserHitView view);
            view.Lifetime = _laserHitData.LifeTime;
            view.EndOfLifetime += delegate(LaserHitView laserHitView) {_laserHitPool.Release(laserHitView);  };
            return view;
        }
        
        private void GetExplosion(LaserHitView obj)
        {
            obj.gameObject.SetActive(true);
        }

        private void ReleaseExplosion(LaserHitView obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}