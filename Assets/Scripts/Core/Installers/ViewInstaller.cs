using Data;
using UnityEngine;
using Views;
using Zenject;

public class ViewInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private LaserWeaponData _laserWeaponData;
    private PlayerView _playerView;

    public override void InstallBindings()
    {
        BindPlayerView();
        BindCameraView();
        BindLaserWeapon();
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
    private void BindCameraView()
    {
        CameraView cameraView = Container
            .InstantiatePrefabForComponent<CameraView>(
                _cameraData.CameraPrefab,
                Vector3.zero, 
                Quaternion.identity, null);

        Container.Bind<CameraView>().FromInstance(cameraView).AsSingle();
    }
    private void BindLaserWeapon()
    {
        LaserWeaponView laserWeapon = Container
            .InstantiatePrefabForComponent<LaserWeaponView>(
                _laserWeaponData.LaserWeaponPrefab, _playerView.transform);

        Container.Bind<LaserWeaponView>().FromInstance(laserWeapon).AsSingle();
    }
}
