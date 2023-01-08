using System;
using System.Threading.Tasks;
using DG.Tweening;
using Player.Shield;
using Shield.Data;
using UnityEngine;
using Views;
using Zenject;


public sealed class ShieldController
{
    private readonly ShieldHp _shieldHp;
    private readonly ShieldRegenerator _shieldRegenerator;
    private readonly ShieldView _shieldView;
    
    [Inject]
    public ShieldController(ShieldView view, ShieldHp hp, ShieldRegenerator regenerator)
    {
        _shieldView = view;
        _shieldView.OnDamage += ReceiveDamage;
        _shieldHp = hp;
        _shieldRegenerator = regenerator;
        regenerator.OnRegenerationComplete += FinishRegeneration;
    }

    private void ReceiveDamage(float damage)
    {
        _shieldHp.CurrentShieldHp -= damage;
        if (_shieldHp.CurrentShieldHp < 0)
        {
            _shieldHp.CurrentShieldHp = 0;
        }
        _shieldRegenerator.ResetRegeneration();
        _shieldView.ShieldAudioSource.volume = 1f;
        _shieldView.ShieldAudioSource.Play();
    }

    private void FinishRegeneration()
    {
        DOTween.To(() => _shieldView.ShieldAudioSource.volume, x => _shieldView.ShieldAudioSource.volume = x, 0, 3);
    }
}
