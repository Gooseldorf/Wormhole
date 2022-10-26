using UnityEngine;


namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _vcamTarget;
        public CharacterController Controller { get; private set; }
        public Animator PlayerAnimator { get; private set; }

        public Transform VcamTarget => _vcamTarget;

        private void Awake()
        {
            PlayerAnimator = GetComponent<Animator>();
            Controller = GetComponent<CharacterController>();
        }
    }
}

