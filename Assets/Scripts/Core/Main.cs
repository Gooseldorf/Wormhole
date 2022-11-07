using Managers;
using UnityEngine;
using Zenject;


public class Main : MonoBehaviour
{
    private ExecutableManager _executableManager;
    private PlayerInput _playerInput;
    private AsteroidGenerator _asteroidGenerator;

    [Inject]
    private void Construct(PlayerInput input, AsteroidGenerator asteroidGenerator)
    {
        _playerInput = input;
        _asteroidGenerator = asteroidGenerator;
    }

    private void Start()
    {
        _executableManager = new ExecutableManager();
        _executableManager.AddExecutableObject(_playerInput);
        _executableManager.AddExecutableObject(_asteroidGenerator);
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
