using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.BULLETS_DATA)]
    public class BulletsData : ScriptableObject
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _bulletPoolPrefab;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private int _maxPoolCapacity;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _shootDelay;

        public GameObject BulletPrefab => _bulletPrefab;
        public GameObject BulletPoolPrefab => _bulletPoolPrefab;
        public int PoolCapacity => _poolCapacity;
        public int MaxPoolCapacity => _maxPoolCapacity;
        public float BulletSpeed => _bulletSpeed;
        public float ShootDelay => _shootDelay;
    }
}