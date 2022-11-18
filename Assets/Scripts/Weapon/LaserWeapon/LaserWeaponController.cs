using Data;
using UnityEngine;


namespace Controllers
{
    public sealed class LaserWeaponController
    {
        private readonly LaserWeaponData _weaponData;
        private readonly LaserWeaponView _laserWeaponView;
        private readonly LaserBulletsPool _laserBulletsPool;
        private bool _coolDown;
        private int _currentBarrelIndex = 0;
        private float _timer = 0;

        public LaserWeaponController(PlayerInput input, LaserWeaponView view, LaserBulletsPool bulletsPool, LaserWeaponData data)
        {
            _laserWeaponView = view;
            _laserBulletsPool = bulletsPool;
            _weaponData = data;
            input.ShootInput += Shoot;
        }

        private void Shoot()
        {
            _timer += Time.deltaTime;
            if (_timer > _weaponData.ShootDelay)
            {
                GameObject bullet = _laserBulletsPool.Pool.Get();
                bullet.transform.position = _laserWeaponView.LaserWeaponBarrels[_currentBarrelIndex].position;
                bullet.transform.rotation *= _laserWeaponView.LaserWeaponBarrels[_currentBarrelIndex].localRotation;
                bullet.TryGetComponent(out LaserBulletView bulletView);
                bulletView.Lifetime = _weaponData.BulletLifetime;
                bulletView.Rb.velocity = -_laserWeaponView.LaserWeaponBarrels[_currentBarrelIndex].transform.forward * _weaponData.BulletSpeed;
                _timer = 0;
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