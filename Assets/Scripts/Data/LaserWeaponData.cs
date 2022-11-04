using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.LASER_WEAPON_DATA)]
    public class LaserWeaponData: ScriptableObject
    {
        [SerializeField] private GameObject _laserWeaponPrefab;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _bulletPoolPrefab;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _shootDelay;
        [SerializeField] private float _damage;
        [SerializeField] private float _bulletLifetime;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private int _maxPoolCapacity;

        public GameObject LaserWeaponPrefab => _laserWeaponPrefab;
        public GameObject BulletPrefab => _bulletPrefab;
        public GameObject BulletPoolPrefab => _bulletPoolPrefab;
        public float ShootDelay => _shootDelay;
        public float Damage => _damage;
        public float BulletSpeed => _bulletSpeed;
        public int PoolCapacity => _poolCapacity;
        public int MaxPoolCapacity => _maxPoolCapacity;
        public float BulletLifetime => _bulletLifetime;
    }
}