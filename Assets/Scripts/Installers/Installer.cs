using Managers;
using UnityEngine;
using Zenject;


public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ExecutableManager>().AsSingle();
        Container.Bind<SpaceshipControls>().AsSingle();
        Container.Bind<PlayerInput>().AsSingle();
    }
}