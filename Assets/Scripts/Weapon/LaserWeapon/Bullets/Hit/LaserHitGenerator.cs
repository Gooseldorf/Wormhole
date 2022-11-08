using Data;
using Pools;
using UnityEngine;


public class LaserHitGenerator
{
    private readonly LaserHitPool _laserHitPool;
    private readonly LaserHitData _laserHitData;
    
    public LaserHitGenerator(LaserHitData data, LaserHitPool pool)
    {
        _laserHitData = data;
        _laserHitPool = pool;
    }

    public void ShowLaserHit (Vector3 hitPoint, Vector3 velocity)
    {
        LaserHitView laserHitView = _laserHitPool.Pool.Get();
        laserHitView.transform.position = hitPoint;
        laserHitView.Rb.velocity = velocity * _laserHitData.HitVelocityMultiplier;
    }
}
