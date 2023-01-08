using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.CAMERA_DATA)]
    public class CameraData: ScriptableObject
    {
        [SerializeField] private GameObject _cameraPrefab;
        [SerializeField] private float _noiseAmplitude;
        [SerializeField] private float _noiseFrequency;

        public GameObject CameraPrefab => _cameraPrefab;
        public float NoiseAmplitude => _noiseAmplitude;
        public float NoiseFrequency => _noiseFrequency;
    }
}