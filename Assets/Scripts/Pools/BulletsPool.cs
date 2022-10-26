using System;
using Data;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;


public class BulletsPool : MonoBehaviour
{
    private BulletsData _bulletsData;
    private ObjectPool<GameObject> _bulletsPool;

    [Inject]
    public void Construct (BulletsData data)
    {
        _bulletsData = data;
    }

    private void Awake()
    {
        /*_bulletsPool = new ObjectPool<GameObject>(CreateBullet, GetBullet, ReleaseBullet,
            bullet => Destroy(bullet.gameObject), true,
            _bulletsData.PoolCapacity, _bulletsData.MaxPoolCapacity);*/
    }

    /*
    private GameObject CreateBullet()
    {
        
    }
    */

    private void GetBullet(GameObject arg0)
    {
        
    }  
    
    private void ReleaseBullet(GameObject arg0)
    {
        
    }
}
