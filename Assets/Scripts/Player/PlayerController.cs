using System;
using Data;
using DG.Tweening;
using UnityEngine;
using Views;


namespace Controllers
{
    public sealed class PlayerController
    {
        private PlayerInput _playerInput;
        private PlayerView _playerView;
        private PlayerData _playerData;
        private Rigidbody _rb;

        public PlayerController(PlayerInput input, PlayerData data, PlayerView view)
        {
            _playerData = data;
            _playerInput = input;
            _playerView = view;
            _rb = _playerView.PlayerRb;
            input.MoveInput += Move;
        }

        private void Move(Vector3 moveInput)
        {
            _rb.AddRelativeForce(new Vector3(0,moveInput.y) * _playerData.PlayerSpeed, ForceMode.Acceleration);
            if ( moveInput.x != 0)
            {
                _playerView.transform.DORotate(new Vector3(0, 0, _playerData.RotationSpeed) 
                                                    * moveInput.x, _playerData.AnimationDuration, RotateMode.LocalAxisAdd);
            }
        }
    }
}