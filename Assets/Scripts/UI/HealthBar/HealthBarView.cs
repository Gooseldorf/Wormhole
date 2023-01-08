using UnityEngine;
using UnityEngine.UI;


namespace UI.HealthBar
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        
        public Image HealthBar
        {
            get => _healthBar;
            set => _healthBar = value;
        }
    }
}
