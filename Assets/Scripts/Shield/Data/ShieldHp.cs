using System;
using UnityEngine;


namespace Shield.Data
{
    [CreateAssetMenu(menuName = "My Assets/" + Constants.SHIELD_HP_COMPONENT)]
    public sealed class ShieldHp : ScriptableObject
    {
        private float _currentShieldHp;

        public event Action OnValueChange;
        public float CurrentShieldHp
        {
            get => _currentShieldHp;
            set
            {
                _currentShieldHp = value;
                OnValueChange?.Invoke();
            }
            
        }
    }
}
