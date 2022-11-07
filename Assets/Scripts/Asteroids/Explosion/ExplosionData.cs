using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.EXPLOSION_DATA)]
    public sealed class ExplosionData: ScriptableObject
    {
        [SerializeField] private GameObject _explosionPoolPrefab;
        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private int _explosionPoolCapacity;
        [SerializeField] private int _explosionMaxPoolCapacity;
        [SerializeField] private float _lifeTime;
        public GameObject ExplosionPrefab => _explosionPrefab;
        public GameObject ExplosionPoolPrefab => _explosionPoolPrefab;
        public int ExplosionPoolCapacity => _explosionPoolCapacity;
        public int ExplosionMaxPoolCapacity => _explosionMaxPoolCapacity;
        public float LifeTime => _lifeTime;
    }
}