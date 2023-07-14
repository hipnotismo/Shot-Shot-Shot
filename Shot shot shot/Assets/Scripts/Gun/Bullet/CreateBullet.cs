using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Class that manages the bullet pool
/// </summary>
public class CreateBullet : MonoBehaviour
{
    [SerializeField] private GunProjectileData BulletData;
    [SerializeField] private float DestroyTime;
    [SerializeField] private float ForceModifier = 50.0f;
    private Vector3 Destination;
    private Vector3 BulletSpawnPointRef;

    [SerializeField] private BaseBullet BaseBulletPrefab;

    private ObjectPool<BaseBullet> BulletPool;

    /// <summary>
    /// Creates a BaseBullet pool
    /// </summary>
    private void Awake()
    {
        BulletPool = new ObjectPool<BaseBullet>(CreateBullets, OnGetBullet, OnReleaseBullet, OnDestroyBullet,
                                              false, 40, 100);
    }

    /// <summary>
    /// Instantiates a new bullet and adds it to the pool if posible
    /// </summary>
    /// <returns></returns>
    private BaseBullet CreateBullets()
    {
        BaseBullet bullet = Instantiate(BaseBulletPrefab, BulletSpawnPointRef, Quaternion.identity);
        bullet.SetPool(BulletPool);
        return bullet;
    }

    /// <summary>
    /// What happens when a bullet is requested/ get action
    /// </summary>
    /// <param name="bullet"></param>
    private void OnGetBullet(BaseBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<Rigidbody>().AddForce((Destination - bullet.transform.position).normalized * ForceModifier, ForceMode.Impulse);
        bullet.transform.position = BulletSpawnPointRef;
    }

    /// <summary>
    /// What happens when the a bullet is release
    /// </summary>
    /// <param name="bullet"></param>
    private void OnReleaseBullet(BaseBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    /// <summary>
    /// What happens when if there are more bullets in the pool that it should
    /// </summary>
    /// <param name="bullet"></param>
    private void OnDestroyBullet(BaseBullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    /// <summary>
    /// Sets local destination
    /// </summary>
    /// <param name="TempDestination"></param>
    private void SetDestination(Vector3 TempDestination)
    {
        Destination = TempDestination;
    }

    /// <summary>
    /// Sets local spawn point
    /// </summary>
    /// <param name="TempSpawnPoint"></param>
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

        BulletPool?.Get();
    }
}
