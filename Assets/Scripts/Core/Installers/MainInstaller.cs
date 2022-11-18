using Controllers;
using Data;
using Player.Shield;
using Pools;
using Shield.Data;
using UI.HealthBar;
using UnityEngine;
using Views;
using Wormhole;
using Wormhole.Data;
using Zenject;


public sealed class MainInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ShieldData _shieldData;
    [SerializeField] private ShieldHp _shieldHp;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private WormholeData _wormholeData;
    [SerializeField] private AsteroidData _asteroidData;
    [SerializeField] private ExplosionData _explosionData;
    [SerializeField] private LaserWeaponData _laserWeaponData;
    [SerializeField] private LaserHitData _laserHitData;
    [SerializeField] private UIData _uiData;
    private PlayerView _playerView;
    private WormholeVisualView _wormholeVisualView;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(_playerData);
        Container.Bind<SpaceshipControls>().AsSingle();
        Container.Bind<PlayerInput>().AsSingle();
        BindPlayerView();
        Container.Bind<PlayerController>().AsSingle().NonLazy();

        Container.Bind<ShieldData>().FromInstance(_shieldData);
        Container.Bind<ShieldHp>().FromInstance(_shieldHp);
        BindShieldView();
        Container.Bind<ShieldRegenerator>().AsSingle().NonLazy();
        Container.Bind<ShieldController>().AsSingle().NonLazy();
        Container.Bind<ShieldVisualEffects>().AsSingle().NonLazy();

        Container.Bind<CameraData>().FromInstance(_cameraData);
        BindCameraView();
        Container.Bind<CameraController>().AsSingle().NonLazy();

        Container.Bind<WormholeData>().FromInstance(_wormholeData);
        BindWormholeVisualView();
        BindWormholeBorderView();
        Container.Bind<WormholeBorderController>().AsSingle().NonLazy();

        Container.Bind<AsteroidData>().FromInstance(_asteroidData);
        BindAsteroidPool();
        BindAsteroidReleaser();
        Container.Bind<AsteroidGenerator>().AsSingle().NonLazy();

        Container.Bind<LaserHitData>().FromInstance(_laserHitData);
        BindLaserHitPool();
        Container.Bind<LaserHitGenerator>().AsSingle().NonLazy();
        
        Container.Bind<LaserWeaponData>().FromInstance(_laserWeaponData);
        BindLaserBulletsPool();
        BindLaserWeapon();
        Container.Bind<LaserWeaponController>().AsSingle().NonLazy();
        
        Container.Bind<ExplosionData>().FromInstance(_explosionData);
        BindExplosionPool();
        Container.Bind<ExplosionGenerator>().AsSingle().NonLazy();

        Container.Bind<UIData>().FromInstance(_uiData);
        BindHealthBarView();
        Container.Bind<HealthBarController>().AsSingle().NonLazy();
    }

    private void BindHealthBarView()
    {
        HealthBarView healthBarView = Container
            .InstantiatePrefabForComponent<HealthBarView>(
                _uiData.HealthBarCanvasPrefab);
        Container.Bind<HealthBarView>().FromInstance(healthBarView);
    }

    private void BindPlayerView()
    {
        PlayerView playerView = Container
            .InstantiatePrefabForComponent<PlayerView>(
                _playerData.PlayerPrefab,
                _playerData.StartPoint,
                Quaternion.Euler(_playerData.StartRotation), null);
        
        Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
        _playerView = playerView;
    }  
    
    private void BindShieldView()
    {
        ShieldView shieldView = Container
            .InstantiatePrefabForComponent<ShieldView>(
            _shieldData.ShieldPrefab,
            _playerView.transform);
        
        Container.Bind<ShieldView>().FromInstance(shieldView);
    }
    
    private void BindCameraView()
    {
        CameraView cameraView = Container
            .InstantiatePrefabForComponent<CameraView>(
                _cameraData.CameraPrefab,
                Vector3.zero, 
                Quaternion.identity, null);
        
        Container.Bind<CameraView>().FromInstance(cameraView).AsSingle();
    }
    
    private void BindWormholeVisualView()
    {
        WormholeVisualView wormholeVisualView = Container
            .InstantiatePrefabForComponent<WormholeVisualView>(
                _wormholeData.WormholeVisualPrefab);
        _wormholeVisualView = wormholeVisualView;
        Container.Bind<WormholeVisualView>().FromInstance(wormholeVisualView).AsSingle();
    }
    
    private void BindWormholeBorderView()
    {
        WormholeBorderView wormholeView = Container
            .InstantiatePrefabForComponent<WormholeBorderView>(
                _wormholeData.WormholeBorderPrefab,
                _wormholeVisualView.transform);
        
        Container.Bind<WormholeBorderView>().FromInstance(wormholeView).AsSingle();
    }
    
    private void BindLaserWeapon()
    {
        LaserWeaponView laserWeapon = Container
            .InstantiatePrefabForComponent<LaserWeaponView>(
                _laserWeaponData.LaserWeaponPrefab, _playerView.transform);

        Container.Bind<LaserWeaponView>().FromInstance(laserWeapon).AsSingle();
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
    
    private void BindLaserHitPool()
    {
        LaserHitPool laserHitPool = Container
            .InstantiatePrefabForComponent<LaserHitPool>(
                _laserHitData.LaserHitPoolPrefab,
                Vector3.zero, Quaternion.identity, null);

        Container.Bind<LaserHitPool>().FromInstance(laserHitPool).AsSingle();
    }   
    
    private void BindExplosionPool()
    {
        ExplosionPool explosionPool = Container
            .InstantiatePrefabForComponent<ExplosionPool>(
                _explosionData.ExplosionPoolPrefab,
                Vector3.zero, Quaternion.identity, null);

        Container.Bind<ExplosionPool>().FromInstance(explosionPool).AsSingle();
    }  
}