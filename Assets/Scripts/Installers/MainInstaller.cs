using Controllers;
using Data;
using UnityEngine;
using Zenject;

public sealed class MainInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private AsteroidData _asteroidData;
    [SerializeField] private LaserWeaponData _laserWeaponData;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(_playerData);
        Container.Bind<SpaceshipControls>().AsSingle();
        Container.Bind<PlayerInput>().AsSingle();
        Container.Bind<PlayerController>().AsSingle().NonLazy();
        
        Container.Bind<CameraData>().FromInstance(_cameraData);
        Container.Bind<CameraController>().AsSingle().NonLazy();

        Container.Bind<AsteroidData>().FromInstance(_asteroidData);
        BindAsteroidPool();
        BindAsteroidReleaser();
        Container.Bind<AsteroidGenerator>().AsSingle().NonLazy();

        Container.Bind<LaserWeaponData>().FromInstance(_laserWeaponData);
        BindLaserBulletsPool();
        Container.Bind<LaserWeaponController>().AsSingle().NonLazy();
    }
    
    private void BindAsteroidPool()
    {
        AsteroidPool asteroidPool = Container
            .InstantiatePrefabForComponent<AsteroidPool>(
                _asteroidData.AsteroidPoolPrefab,
                Vector3.zero, Quaternion.identity, null);

        Container.Bind<AsteroidPool>().FromInstance(asteroidPool).AsSingle();
    }   
    private void BindAsteroidReleaser()
    {
        AsteroidReleaser asteroidReleaser = Container
            .InstantiatePrefabForComponent<AsteroidReleaser>(
                _asteroidData.AsteroidReleaserPrefab);

        Container.Bind<AsteroidReleaser>().FromInstance(asteroidReleaser).AsSingle();
    }  
    private void BindLaserBulletsPool()
    {
        LaserBulletsPool laserBulletsPool = Container
            .InstantiatePrefabForComponent<LaserBulletsPool>(
                _laserWeaponData.BulletPoolPrefab,
                Vector3.zero, Quaternion.identity, null);

        Container.Bind<LaserBulletsPool>().FromInstance(laserBulletsPool).AsSingle();
    }   
}