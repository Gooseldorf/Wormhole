using System;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;


public sealed class PlayerInput : IExecute
{
    private readonly SpaceshipControls _spaceshipControls;
    private bool _isShooting;
    public event Action <Vector3> MoveInput;
    public event Action ShootInput;


    public PlayerInput(SpaceshipControls controls)
    {
        _spaceshipControls = controls;
        _spaceshipControls.Enable();
    }
    
    public void Update()
    {
        Vector2 moveInput = _spaceshipControls.Spaceship2D.Move.ReadValue<Vector2>();
        MoveInput?.Invoke(new Vector3(moveInput.x, moveInput.y, 0f));

        if (_spaceshipControls.Spaceship2D.LaserShoot.ReadValue<float>() > 0)
        {
            ShootInput?.Invoke();
        }

        if (_spaceshipControls.Spaceship2D.Pause.triggered)
        {
            GameStateController.IsGamePaused = true;
        }
    }
}
