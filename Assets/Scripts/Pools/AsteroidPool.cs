using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Views;

public class AsteroidPool : MonoBehaviour
{
    private List<AsteroidView> _asteroidPrefabs;
    private List<AsteroidView> _asteroidsList;
    private int _asteroidsPoolCapacity;
    
    private ObjectPool<AsteroidView> _asteroidsPool;
    public ObjectPool<AsteroidView> AsteroidsPool => _asteroidsPool;
    
    private void Awake()
    {
        _asteroidsPool = new ObjectPool<AsteroidView>(CreateAsteroid, GetAsteroid, ReleaseAsteroid,
            asteroid => Destroy(asteroid.gameObject), true, _asteroidsPoolCapacity, 200);
    }
    
    private AsteroidView CreateAsteroid()
    {
        int index = Random.Range(0, _asteroidPrefabs.Count-1);
        AsteroidView asteroid = Instantiate(_asteroidPrefabs[index]);
        return asteroid;
    }
    private void ReleaseAsteroid(AsteroidView obj)
    {
        obj.gameObject.SetActive(false); 
    }
    private void GetAsteroid(AsteroidView obj)
    {
        obj.gameObject.SetActive(true);
    }
}
