using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.PLAYER_DATA)]
    public sealed class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Vector3 _startPoint;
        [SerializeField] private Vector3 _startRotation;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _animationDuration;
   
        public GameObject PlayerPrefab => _playerPrefab;
        public Vector3 StartPoint => _startPoint;
        public Vector3 StartRotation => _startRotation;
        public float PlayerSpeed
        {
            get => _playerSpeed;
            set => _playerSpeed = value;
        }
        public float RotationSpeed => _rotationSpeed;
        public float AnimationDuration => _animationDuration;
    }
}
