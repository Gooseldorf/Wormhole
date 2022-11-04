using Data;
using Interfaces;
using UnityEngine;
using Views;
using Random = UnityEngine.Random;

public sealed class AsteroidGenerator : IExecute
{
    private readonly AsteroidPool _asteroidPool;
    private readonly AsteroidData _asteroidData;
    private float timer = 0;

    public AsteroidGenerator(AsteroidPool asteroidPool, AsteroidData data)
    {
        _asteroidData = data;
        _asteroidPool = asteroidPool;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > _asteroidData.SpawnTime)
        {
            CreateAsteroids();
            timer = 0;
        }
    }

    public void CreateAsteroids()
    {
        for (int i = 0; i < _asteroidData.StartSpawnAmount; i++)
        {
            GameObject asteroid = _asteroidPool.AsteroidsPool.Get();
            asteroid.transform.localPosition = RandomV3(true);
            asteroid.transform.localRotation = Quaternion.Euler(RandomV3(false));
            asteroid.transform.localScale = new Vector3(1,1,1);
            
            float sizeMultiplier = Random.Range(_asteroidData.MinScale, _asteroidData.MaxScale);
            asteroid.transform.localScale *= sizeMultiplier;
            asteroid.TryGetComponent(out AsteroidView asteroidView);
            asteroidView.CurrentHealth = _asteroidData.BaseHealth * sizeMultiplier;
        }
    }

    private Vector3 RandomV3(bool forPosition)
    {
        if (forPosition)
        {
            float rX = Random.Range(-_asteroidData.MaxX, _asteroidData.MaxX);
            float rY = Random.Range(-_asteroidData.MaxY, _asteroidData.MaxY);

            return new Vector3(rX, rY, _asteroidData.SpawnDistance);
        }
        else
        {
            float rX = Random.Range(0, 360);
            float rY = Random.Range(0, 360);
            float rZ = Random.Range(0, 360);

            return new Vector3(rX, rY, rZ);
        }
    }
}
