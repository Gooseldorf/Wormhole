using System;
using UnityEngine;
using Views;


namespace Wormhole
{
    public sealed class WormholeBorderView : MonoBehaviour
    {
        public event Action<ShieldView> OnPlayerCrossTheBoard;
    
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out AsteroidView asteroid))
            {
                asteroid.ReleaseRequest?.Invoke(asteroid);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ShieldView playerShieldView))
            {
                OnPlayerCrossTheBoard?.Invoke(playerShieldView);
            }
        }
    }
}
