using UnityEngine;
using UnityEngine.Pool;

public class BaseBullet : MonoBehaviour
{
    private IObjectPool<BaseBullet> m_pool;

    public void SetPool(IObjectPool<BaseBullet> pool)
    {
        m_pool = pool;
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_pool?.Release(this);

    }

    public void SetPosition(Vector3 PositionRef)
    {
        transform.position = PositionRef;
    }
    
}
