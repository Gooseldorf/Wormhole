using Managers;
using Player.Shield;
using UnityEngine;
using Zenject;


public sealed class Main : MonoBehaviour
{
    private ExecutableManager _executableManager;
    private PlayerInput _playerInput;
    private AsteroidGenerator _asteroidGenerator;
    private ShieldRegenerator _shieldRegenerator;
    private ShieldVisualEffects _shieldVisualEffects;

    [Inject]
    private void Construct(PlayerInput input, AsteroidGenerator asteroidGenerator, ShieldRegenerator shieldRegenerator,
        ShieldVisualEffects shieldVisualEffects)
    {
        _playerInput = input;
        _asteroidGenerator = asteroidGenerator;
        _shieldRegenerator = shieldRegenerator;
        _shieldVisualEffects = shieldVisualEffects;
    }

    private void Start()
    {
        _executableManager = new ExecutableManager();
        _executableManager.AddExecutableObject(_playerInput);
        _executableManager.AddExecutableObject(_asteroidGenerator);
        _executableManager.AddExecutableObject(_shieldRegenerator);
        _executableManager.AddExecutableObject(_shieldVisualEffects);
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
