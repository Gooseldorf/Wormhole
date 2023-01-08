using System.Threading.Tasks;
using UnityEngine;
using Views;
using Wormhole.Data;


namespace Wormhole
{
    public sealed class WormholeBorderController
    {
        private readonly WormholeData _wormholeData;
        private readonly PlayerView _playerView;

        public WormholeBorderController(WormholeData data, WormholeBorderView border, PlayerView player)
        {
            _wormholeData = data;
            border.OnPlayerCrossTheBoard += DamageAndPushPlayer;
            _playerView = player;
        }

        private async void DamageAndPushPlayer(ShieldView shield)
        {
            Vector3 direction = (- _playerView.transform.position) * _wormholeData.PushForceMultiplier;
            _playerView.PlayerRb.AddForce(direction,ForceMode.Impulse);
            await Task.Delay(100);
            shield.ReceiveDamage(_wormholeData.Damage);
        

        }
    }
}
