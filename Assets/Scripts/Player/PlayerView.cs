using System;
using UnityEngine;


namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _vcamTarget;
        [SerializeField] private AudioSource _engineAudioSource;
        private Rigidbody _rb;
        public Transform VcamTarget => _vcamTarget;
        public Rigidbody PlayerRb => _rb;
        public AudioSource EngineAudioSource => _engineAudioSource;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
    }
}

