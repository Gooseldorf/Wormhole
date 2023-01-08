using System;
using Interfaces;
using Shield.Data;
using UnityEngine;
using Zenject;


namespace Player.Shield
{
    public sealed class ShieldRegenerator: IExecute
    {
        private readonly ShieldData _shieldData;
        private readonly ShieldHp _shieldHp;
        private bool _canRegenerate;
        private float _timer;

        public event Action OnRegenerationComplete;

        [Inject]
        public ShieldRegenerator(ShieldHp hp, ShieldData data)
        {
            _shieldData = data;
            _shieldHp = hp;
        }
        
        public void Update()
        {
            if (_timer >= 0)
            {
                CountTimeBeforeRegeneration();
            }
            if (_canRegenerate)
            {
                Regenerate();
            }
        }

        public void ResetRegeneration()
        {
            _timer = 0;
            _canRegenerate = false;
        }
        
        private void CountTimeBeforeRegeneration()
        {
            if (_timer < _shieldData.TimeBeforeRegeneration)
            {
                _timer += Time.deltaTime;
            }
            else   
            {
                _canRegenerate = true;
                _timer = -1;
            }
        }
        
        private void Regenerate()
        {
            if (_shieldHp.CurrentShieldHp < _shieldData.ShieldStartHp)
            {
                _shieldHp.CurrentShieldHp += _shieldData.RegenerationValueInSecond * Time.deltaTime;
            }
            else
            {
                _canRegenerate = false;
                OnRegenerationComplete?.Invoke();
                ClampMaxHealth();
            }
        }
        
        private void ClampMaxHealth()
        {
            if (_shieldHp.CurrentShieldHp > _shieldData.ShieldStartHp)
            {
                _shieldHp.CurrentShieldHp = _shieldData.ShieldStartHp;
            }
        }
    }
}