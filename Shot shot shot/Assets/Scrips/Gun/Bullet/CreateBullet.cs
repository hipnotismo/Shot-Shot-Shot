using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [SerializeField] GunProjectileData BulletData;

    public void BulletCreation(Vector3 BulletSpawnPoint, Vector3 destination)
    {
        GameObject projectile = Instantiate(BulletData.Bullet, BulletSpawnPoint, Quaternion.identity);
        //TODO: Fix - Hardcoded value
        Destroy(projectile, 1f);
        //TODO: Fix - Hardcoded value
        projectile.GetComponent<Rigidbody>().AddForce((destination - projectile.transform.position).normalized * 50.0f, ForceMode.Impulse);
    }
}
