using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Base class for poolable bullets
/// </summary>
public class BaseBullet : MonoBehaviour
{
    private IObjectPool<BaseBullet> Pool;
    /// <summary>
    /// Sets current pool
    /// </summary>
    /// <param name="pool"></param>
    public void SetPool(IObjectPool<BaseBullet> pool)
    {
        Pool = pool;
    }

    /// <summary>
    /// Condition for the release of a polled object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Pool?.Release(this);

    }

    /// <summary>
    /// Sets transform position
    /// </summary>
    /// <param name="PositionRef"></param>
    public void SetPosition(Vector3 PositionRef)
    {
        transform.position = PositionRef;
    }
    
}
