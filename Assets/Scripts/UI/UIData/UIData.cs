using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/" + Constants.UI_DATA)]
public sealed class UIData : ScriptableObject
{
    [SerializeField] private GameObject _canvasPrefab;
    [SerializeField] private GameObject _healthBarCanvasPrefab;
    [SerializeField] private GameObject _scoreCanvasPrefab;
    [SerializeField] private GameObject _weaponLoadingCanvasPrefab;

    public GameObject CanvasPrefab => _canvasPrefab;
    public GameObject HealthBarCanvasPrefab => _healthBarCanvasPrefab;
    public GameObject ScoreCanvasPrefab => _scoreCanvasPrefab;
    public GameObject WeaponLoadingCanvasPrefab => _weaponLoadingCanvasPrefab;
}
