using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/" + Constants.SHIELD_DATA)]
public sealed class ShieldData : ScriptableObject
{
    [SerializeField] private GameObject _shieldPrefab;
    
    [Header("ShaderSettings")]
    [SerializeField] private Shader _shieldShader;
    [SerializeField] private Material _shieldMaterial;
    [SerializeField] private Texture _shieldMainTexture;
    [SerializeField] private Color _mainColor;
    [SerializeField] private Texture _emissionTexture;
    [SerializeField] private Color _emissionColor;
    [SerializeField] private Vector2 _mainTiling;
    [SerializeField] private Texture _gradientTexture;
    [SerializeField] private Color _gradientColor;
    [SerializeField] private Vector2 _gradientTiling;
    [SerializeField] [Range(0,2)] private float _shieldSpeed;
    [SerializeField] [Range(0, 1)] private float _shieldAlpha;

    [Header("Shield Settings")]
    [SerializeField] private float _shieldStartHp;
    [SerializeField] private float _timeBeforeRegeneration;
    [SerializeField] private float _regenerationValueInSecond;
    
    [Header("Visual Settings")]
    [SerializeField] private float _fadingSpeedAfterImpact;
    [SerializeField] private float _cameraShakeTime;
    [SerializeField] private float _cameraShakeMultiplier;

    
    public GameObject ShieldPrefab => _shieldPrefab;
    public float ShieldAlpha => _shieldAlpha;
    public float ShieldStartHp => _shieldStartHp;
    public float TimeBeforeRegeneration => _timeBeforeRegeneration;
    public float RegenerationValueInSecond => _regenerationValueInSecond;
    public float FadingSpeedAfterImpact => _fadingSpeedAfterImpact;
    public float CameraShakeTime => _cameraShakeTime;
    public float CameraShakeMultiplier => _cameraShakeMultiplier;
}
