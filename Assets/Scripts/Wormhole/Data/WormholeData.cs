using UnityEngine;

namespace Wormhole.Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.WORMHOLE_DATA)]
    public class WormholeData : ScriptableObject
    {
        [SerializeField] private GameObject _wormholeVisualPrefab;
        [SerializeField] private GameObject _wormholeBorderPrefab;
        [SerializeField] private float _damage;
        [SerializeField] private float _pushForceMultiplier;

        public GameObject WormholeVisualPrefab => _wormholeVisualPrefab;
        public GameObject WormholeBorderPrefab => _wormholeBorderPrefab;
        public float Damage => _damage;
        public float PushForceMultiplier => _pushForceMultiplier;
    }
}
