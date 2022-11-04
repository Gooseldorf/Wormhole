using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.Pool;
using Views;
using Zenject;


public class AsteroidPool : MonoBehaviour
{
    private AsteroidData _asteroidData;
    private List<GameObject> _asteroidPrefabs;
    private ObjectPool<GameObject> _asteroidsPool;
    public ObjectPool<GameObject> AsteroidsPool => _asteroidsPool;
    
    [Inject]
    private void Construct(AsteroidData data)
    {
        _asteroidData = data;
    }
    private void Awake()
    {
        _asteroidPrefabs = _asteroidData.AsteroidPrefabs;
        _asteroidsPool = new ObjectPool<GameObject>(CreateAsteroid, GetAsteroid, ReleaseAsteroid, 
            asteroid => Destroy(asteroid.gameObject), true,
            _asteroidData.PoolCapacity, _asteroidData.MaxPoolCapacity);
    }
    
    private GameObject CreateAsteroid()
    {
        int index = Random.Range(0, _asteroidPrefabs.Count-1);
        GameObject asteroid = Instantiate(_asteroidPrefabs[index]);
        asteroid.TryGetComponent(out AsteroidView asteroidView);
        asteroidView.ReleaseRequest += delegate(AsteroidView view) {_asteroidsPool.Release(asteroid);};
        return asteroid;
    }
    private void ReleaseAsteroid(GameObject obj)
    {
        obj.gameObject.SetActive(false); 
    }
    private void GetAsteroid(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }
}
