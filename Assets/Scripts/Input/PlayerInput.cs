using System;
using Interfaces;
using UnityEngine;
using Zenject;


public sealed class PlayerInput : IExecute
{
    private readonly SpaceshipControls _spaceshipControls;
    public event Action <Vector3> MoveInput;

    public PlayerInput(SpaceshipControls controls)
    {
        _spaceshipControls = controls;
        _spaceshipControls.Enable();
    }
    
    public void Update()
    {
        Vector2 input = _spaceshipControls.Spaceship2D.Move.ReadValue<Vector2>();
        MoveInput?.Invoke(new Vector3(input.x, input.y, 0f));
    }
}
