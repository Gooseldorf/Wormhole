using Data;
using UnityEngine;


namespace Controllers
{
    public sealed class LaserWeaponController
    {
        private PlayerInput _playerInput;
        private LaserWeaponData _weaponData;
        private LaserWeaponView _laserWeaponView;
        private LaserBulletsPool _laserBulletsPool;
        private bool _coolDown;
        private int _currentBarrelIndex = 0;
        private float timer = 0;

        public LaserWeaponController(PlayerInput input, LaserWeaponView view, LaserBulletsPool bulletsPool, LaserWeaponData data)
        {
            _playerInput = input;
            _laserWeaponView = view;
            _laserBulletsPool = bulletsPool;
            _weaponData = data;
            _playerInput.ShootInput += Shoot;
        }

        private void Shoot()
        {
            timer += Time.deltaTime;
            if (timer > _weaponData.ShootDelay)
            {
                GameObject bullet = _laserBulletsPool.Pool.Get();
                bullet.transform.position = _laserWeaponView.LaserWeaponBarrels[_currentBarrelIndex].position;
                bullet.transform.rotation *= _laserWeaponView.LaserWeaponBarrels[_currentBarrelIndex].localRotation;
                bullet.TryGetComponent(out LaserBulletView bulletView);
                bulletView.Lifetime = _weaponData.BulletLifetime;
                bulletView.Rb.velocity = -_laserWeaponView.LaserWeaponBarrels[_currentBarrelIndex].transform.forward * _weaponData.BulletSpeed;
                timer = 0;
                if (_currentBarrelIndex != _laserWeaponView.LaserWeaponBarrels.Count - 1)
                {
                    _currentBarrelIndex++;
                }
                else
                {
                    _currentBarrelIndex = 0;
                }
            }
        }
    }
}