using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [SerializeField] GunProjectileData BulletData;
    [SerializeField] float DestroyTime;
    [SerializeField] float ForceModifier = 50.0f;

    public void BulletCreation(Vector3 BulletSpawnPoint, Vector3 destination)
    {
        GameObject projectile = Instantiate(BulletData.Bullet, BulletSpawnPoint, Quaternion.identity);
        Destroy(projectile, DestroyTime);
        //TODO: Fix - Hardcoded value
        projectile.GetComponent<Rigidbody>().AddForce((destination - projectile.transform.position).normalized * ForceModifier, ForceMode.Impulse);
    }
}
