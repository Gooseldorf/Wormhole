using System;
using Controllers;
using Data;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private AsteroidData _asteroidData;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(_playerData);
        Container.Bind<SpaceshipControls>().AsSingle();
        Container.Bind<PlayerInput>().AsSingle();
        Container.Bind<PlayerController>().AsSingle().NonLazy();
        
        Container.Bind<CameraData>().FromInstance(_cameraData);
        Container.Bind<CameraController>().AsSingle().NonLazy();
    }
}