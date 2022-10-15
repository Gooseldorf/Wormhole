using System;
using Managers;
using UnityEngine;
using Zenject;


public class Main : MonoBehaviour
{
    private ExecutableManager _executableManager;
    private PlayerInput _playerInput;
    
    [Inject]
    private void Construct(ExecutableManager executableManager, PlayerInput playerInput)
    {
        _executableManager = executableManager;
        _playerInput = playerInput;
    }
    
    private void Start()
    {
        _executableManager.AddExecutableObject(_playerInput);
    }

    private void Update()
    {
        for (int i = 0; i < _executableManager.Length; i++)
        {
            if(_executableManager[i] == null)
                continue;
            _executableManager[i].Update();
        }
    }
}
