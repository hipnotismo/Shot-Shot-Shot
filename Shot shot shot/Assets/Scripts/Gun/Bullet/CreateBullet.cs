using UnityEngine;

/// <summary>
/// Class that instantiates bullets
/// </summary>
public class CreateBullet : MonoBehaviour
{
    [SerializeField] private GunProjectileData BulletData;
    [SerializeField] private float DestroyTime;
    [SerializeField] private float ForceModifier = 50.0f;

    /// <summary>
    /// Instantiates a prefab and adds force to it
    /// </summary>
    /// <param name="BulletSpawnPoint"></param>
    /// <param name="destination"></param>
    public void BulletCreation(Vector3 BulletSpawnPoint, Vector3 destination)
    {
        GameObject projectile = Instantiate(BulletData.Bullet, BulletSpawnPoint, Quaternion.identity);
        Destroy(projectile, DestroyTime);
        projectile.GetComponent<Rigidbody>().AddForce((destination - projectile.transform.position).normalized * ForceModifier, ForceMode.Impulse);
    }
}
