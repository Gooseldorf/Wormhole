using Data;
using DG.Tweening;
using UnityEngine;
using Views;


namespace Controllers
{
    public class PlayerController
    {
        private PlayerInput _playerInput;
        private PlayerView _playerView;
        private PlayerData _playerData;
      

        public PlayerController(PlayerInput input, PlayerData data, PlayerView view)
        {
            _playerData = data;
            _playerInput = input;
            _playerView = view;
            
            input.MoveInput += Move;
        }

        private void Move(Vector3 input)
        {
            _playerView.Controller.Move(input * (Time.deltaTime * _playerData.PlayerSpeed));

            if (input.y != 0)
            {
                if (_playerView.transform.rotation.eulerAngles.x is < 30 or > 330)
                {
                    _playerView.transform.DORotate(new Vector3(5, 0, 0) * input.y, 1, RotateMode.LocalAxisAdd);
                }
            }
            else
            {
                _playerView.transform.DORotate(new Vector3(0, 180, _playerView.transform.rotation.eulerAngles.z), 3, RotateMode.Fast);
            }
            if ( input.x != 0)
            {
                _playerView.transform.DOLocalRotate(new Vector3(0, 0, 15) * input.x, 1f, RotateMode.LocalAxisAdd);
            }
        }
    }
}