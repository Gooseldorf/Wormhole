using UnityEngine;


namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _vcamTarget;
        private Rigidbody _rb;
        public Transform VcamTarget => _vcamTarget;
        public Rigidbody PlayerRb => _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
    }
}

