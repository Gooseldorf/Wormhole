using System;
using UnityEngine;


namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _vcamTarget;
        private Rigidbody _rb;
        public Transform VcamTarget => _vcamTarget;
        public Rigidbody PlayerRb => _rb;
        [SerializeField] private float _wormholeRadius;
        private float _currentPlayerSquareRadius;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
      
        }
    }
}

