using System.Collections.Generic;
using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.ASTEROID_DATA)]
    public class AsteroidData: ScriptableObject
    {
        [Header("Pool parameters")] 
        [SerializeField] private GameObject _asteroidPoolPrefab;
        [SerializeField] private GameObject _asteroidReleaserPrefab;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private int _maxPoolCapacity;

        [Header("Generator Parameters")] 
        [SerializeField] private float _maxX;
        [SerializeField] private float _maxY;
        [SerializeField] private float _spawnDistance;
        [SerializeField] private float _spawnTime;
        [SerializeField] private float _startSpawnAmount;

        [Header("Asteroids parameters")]
        [SerializeField] private List<GameObject> _asteroidPrefabs;
        [SerializeField] private float _minScale;
        [SerializeField] private float _maxScale;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _maxTumble;
        [SerializeField] private float _baseHealth;
        [SerializeField] private float _baseDamage;
        [SerializeField] private int _awaitBeforeRelease;

        public List<GameObject> AsteroidPrefabs => _asteroidPrefabs;
        public GameObject AsteroidPoolPrefab => _asteroidPoolPrefab;
        public GameObject AsteroidReleaserPrefab => _asteroidReleaserPrefab;
        public float MinScale => _minScale;
        public float MaxScale => _maxScale;
        public float MinSpeed => _minSpeed;
        public float MaxSpeed => _maxSpeed;
        public float MaxTumble => _maxTumble;
        public int PoolCapacity => _poolCapacity;
        public int MaxPoolCapacity => _maxPoolCapacity;
        public float MaxX => _maxX;
        public float MaxY => _maxY;
        public float SpawnDistance => _spawnDistance;
        public float SpawnTime
        {
            get => _spawnTime;
            set => _spawnTime = value;
        }

        public float StartSpawnAmount
        {
            get => _startSpawnAmount;
            set => _startSpawnAmount = value;
        }

        public float BaseHealth => _baseHealth;
        public float BaseDamage => _baseDamage;
        public int AwaitBeforeRelease => _awaitBeforeRelease;
    }
}