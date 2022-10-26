using System.Collections.Generic;
using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.ASTEROID_DATA)]
    public class AsteroidData: ScriptableObject
    {
        [SerializeField] private List<GameObject> _asteroidPrefabs;
        [SerializeField] private int _initialQuantity;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _maxTumble;

        public List<GameObject> AsteroidPrefabs => _asteroidPrefabs;
        public int InitialQuantity => _initialQuantity;
        public float MinSpeed => _minSpeed;
        public float MaxSpeed => _maxSpeed;
        public float MaxTumble => _maxTumble;
    }
}