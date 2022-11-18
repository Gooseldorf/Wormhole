using Shield.Data;
using UI.HealthBar;
using UnityEngine;


public class HealthBarController
{
    private readonly ShieldHp _shieldHp;
    private readonly HealthBarView _healthBarView;
    
    
    public HealthBarController(ShieldHp shieldHp, HealthBarView view)
    {
        _shieldHp = shieldHp;
        _healthBarView = view;
        _shieldHp.OnValueChange += UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        _healthBarView.HealthBar.fillAmount = _shieldHp.CurrentShieldHp / 100;
    }
}
