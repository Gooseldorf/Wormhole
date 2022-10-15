using Interfaces;
using UnityEngine;
using Zenject;


public class PlayerInput : IExecute
{
    private readonly SpaceshipControls _spaceshipControls;

    [Inject]
    public PlayerInput(SpaceshipControls controls)
    {
        _spaceshipControls = controls;
        _spaceshipControls.Enable();
    }


    public void Update()
    {
        
    }
}
