using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.LASER_HIT_DATA)]
    public sealed class LaserHitData: ScriptableObject
    {
        [SerializeField] private GameObject _laserHitPoolPrefab;
        [SerializeField] private GameObject _laserHitPrefab;
        [SerializeField] private int _laserHitPoolCapacity;
        [SerializeField] private int _laserHitMaxPoolCapacity;
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _hitVelocityMultiplier;
        public GameObject LaserHitPrefab => _laserHitPrefab;
        public GameObject LaserHitPoolPrefab => _laserHitPoolPrefab;
        public int LaserHitPoolCapacity => _laserHitPoolCapacity;
        public int LaserHitMaxPoolCapacity => _laserHitMaxPoolCapacity;
        public float LifeTime => _lifeTime;
        public float HitVelocityMultiplier => _hitVelocityMultiplier;
    }
}