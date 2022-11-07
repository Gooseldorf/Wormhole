using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.CAMERA_DATA)]
    public class CameraData: ScriptableObject
    {
        [SerializeField] private GameObject _cameraPrefab;

        public GameObject CameraPrefab => _cameraPrefab;
    }
}