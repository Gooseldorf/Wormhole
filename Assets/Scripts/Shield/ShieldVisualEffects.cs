using Controllers;
using Data;
using DG.Tweening;
using Interfaces;
using UnityEngine;
using Views;
using Zenject;


namespace Player.Shield
{
    public class ShieldVisualEffects: IExecute
    {
        private readonly MeshRenderer _shieldRenderer;
        private readonly ShieldData _shieldData;
        private readonly ShieldView _shieldView;
     
        private CameraController _cameraController;
        private bool _cameraShaking = false;
        private float _shakingTimer;


        private bool _regenerationComplete;
        private bool _shieldIsVisible;
        
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
        private readonly Color _emissionColor;
        private float _emissionMultiplier;
        
        private static readonly int Alpha = Shader.PropertyToID("_Alpha");
        private float _shieldAlpha;
        
        [Inject]
        public ShieldVisualEffects(ShieldView view, CameraController camera, ShieldData data, ShieldRegenerator regenerator)
        {
            _shieldView = view;
            _shieldData = data;
            _cameraController = camera;
            _shieldRenderer = view.ShieldRenderer;
            _emissionColor = view.ShieldRenderer.material.GetColor(EmissionColor);
            _shieldView.OnDamage += ShowShieldImpactVisuals;
            _shakingTimer = _shieldData.CameraShakeTime;
            regenerator.OnRegenerationComplete += () => { _regenerationComplete = true;};
        }
        
        public void Update()
        {
            if(_regenerationComplete)
            {
                FadeShieldVisuals();
            }

            if (_shieldIsVisible)
            {
                UpdateEmission();
            }

            if (_cameraShaking)
            {
                ShakeCamera();
            }
        }

        private void ShakeCamera()
        {
            _shakingTimer -= Time.deltaTime;
            _cameraController.ShakeCameraAction(Mathf.Lerp(1, _shieldData.CameraShakeMultiplier, _shakingTimer));
            if (_shakingTimer < 0)
            {
                _cameraShaking = false;
                _shakingTimer = _shieldData.CameraShakeTime;
            }
        }

        private void ShowShieldVisuals()
        {
            _shieldRenderer.enabled = true;
            _shieldIsVisible = true;
            _shieldRenderer.material.SetFloat(Alpha, _shieldData.ShieldAlpha);
        }
        
        private void ShowShieldImpactVisuals(float damage)
        {
            ShowShieldVisuals();
            _shieldView.ImpactParticles.Play();
            _emissionMultiplier = damage;
            _shieldRenderer.material.SetColor(EmissionColor, _emissionColor * _emissionMultiplier);
            _regenerationComplete = false;
            _cameraShaking = true;
            _shakingTimer = 2;

        }
        
        private void UpdateEmission()
        {
            if (_emissionMultiplier > 1)
            {
                _emissionMultiplier -= Time.deltaTime * _shieldData.FadingSpeedAfterImpact;
                _shieldRenderer.material.SetColor(EmissionColor, _emissionColor * _emissionMultiplier);
            }
            else
            {
                _emissionMultiplier = 1;
                _shieldRenderer.material.SetColor(EmissionColor, _emissionColor * _emissionMultiplier);
            }
        }

        private void FadeShieldVisuals()
        {
            _shieldRenderer.material.SetFloat(Alpha, _shieldAlpha -= Time.deltaTime/100);
            if (_shieldAlpha < 0)
            {
                _shieldAlpha = 0;
                _shieldRenderer.enabled = false;
                _shieldIsVisible = false;
            }
        }
        
    }
}