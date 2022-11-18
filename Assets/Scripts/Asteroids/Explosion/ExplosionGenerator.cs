using Pools;
using Views;


public sealed class ExplosionGenerator
{
    private readonly ExplosionPool _explosionPool;
    
    public ExplosionGenerator(ExplosionPool pool)
    {
        _explosionPool = pool;
        AsteroidView.OnAsteroidDestruction += BlowUpAnAsteroid;
    }

    private void BlowUpAnAsteroid(AsteroidView asteroid)
    {
        ExplosionView explosion = _explosionPool.Pool.Get();
        explosion.transform.position = asteroid.transform.position;
        explosion.Rb.velocity = asteroid.Rb.velocity;
    }
}
