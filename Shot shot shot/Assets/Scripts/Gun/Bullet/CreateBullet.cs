using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Class that instantiates bullets
/// </summary>
public class CreateBullet : MonoBehaviour
{
    [SerializeField] private GunProjectileData BulletData;
    [SerializeField] private float DestroyTime;
    [SerializeField] private float ForceModifier = 50.0f;
    private Vector3 Destination;
    private Vector3 BulletSpawnPointRef;

    [SerializeField] private BaseBullet m_bulletPrefab;

    private ObjectPool<BaseBullet> m_bulletPool;

    private void Awake()
    {
        m_bulletPool = new ObjectPool<BaseBullet>(CreateBullets, OnGetBullet, OnReleaseBullet, OnDestroyBullet,
                                              false, 40, 100);
    }

    private BaseBullet CreateBullets()
    {
        BaseBullet bullet = Instantiate(m_bulletPrefab, BulletSpawnPointRef, Quaternion.identity);
      //  bullet.SetPosition(BulletSpawnPointRef);

        bullet.SetPool(m_bulletPool);
        return bullet;
    }

    private void OnGetBullet(BaseBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<Rigidbody>().AddForce((Destination - bullet.transform.position).normalized * ForceModifier, ForceMode.Impulse);
        bullet.transform.position = BulletSpawnPointRef;
        Debug.Log("Bullet position: " + bullet.transform.position);

    }

    private void OnReleaseBullet(BaseBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(BaseBullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void SetDestination(Vector3 TempDestination)
    {
        Destination = TempDestination;
    }

    private void SetSpawnPoint(Vector3 TempSpawnPoint)
    {
        BulletSpawnPointRef = TempSpawnPoint;
    }
    /// <summary>
    /// Instantiates a prefab and adds force to it
    /// </summary>
    /// <param name="BulletSpawnPoint"></param>
    /// <param name="destination"></param>
    public void BulletCreation(Vector3 BulletSpawnPoint, Vector3 destination)
    {
        SetDestination(destination);
        SetSpawnPoint(BulletSpawnPoint);

        m_bulletPool?.Get();
        Debug.Log("Original postion of spawn " + BulletSpawnPoint);

        //GameObject projectile = Instantiate(BulletData.Bullet, BulletSpawnPoint, Quaternion.identity);
        //Destroy(projectile, DestroyTime);
        //projectile.GetComponent<Rigidbody>().AddForce((destination - projectile.transform.position).normalized * ForceModifier, ForceMode.Impulse);
    }
}
