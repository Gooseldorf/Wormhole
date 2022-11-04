using System.Collections.Generic;
using UnityEngine;


public class LaserWeaponView : MonoBehaviour
{
    [SerializeField] private Transform _barrelUpLeft;
    [SerializeField] private Transform _barrelUpRight;
    [SerializeField] private Transform _barrelDownLeft;
    [SerializeField] private Transform _barrelDownRight;
    private List<Transform> _laserWeaponBarrels;

    public Transform BarrelUpLeft => _barrelUpLeft;
    public Transform BarrelUpRight => _barrelUpRight;
    public Transform BarrelDownLeft => _barrelDownLeft;
    public Transform BarrelDownRight => _barrelDownRight;
    public List<Transform> LaserWeaponBarrels => _laserWeaponBarrels;

    private void Awake()
    {
        _laserWeaponBarrels = new List<Transform>();
        _laserWeaponBarrels.Add(_barrelUpLeft);
        _laserWeaponBarrels.Add(_barrelUpRight);
        _laserWeaponBarrels.Add(_barrelDownLeft);
        _laserWeaponBarrels.Add(_barrelDownRight);
    }
}
