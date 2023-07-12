using UnityEngine;

/// <summary>
/// Base class for all projectile weapons
/// </summary>
public class GunBaseProyect : GunBase
{
    [SerializeField] GunProjectileData BulletData;
    [SerializeField] CreateBullet BulletCreation;

    private Vector3 destination;

    /// <summary>
    /// Set BulletSpawnPoint and subscribes to ShootWeapon
    /// </summary>
    private void OnEnable()
    {
        BulletSpawnPoint = this.transform;
        FireWeapon.ShootWeapon += Shoot;
    }

    /// <summary>
    /// Unsubscribes from ShootWeapon
    /// </summary>
    private void OnDisable()
    {
        FireWeapon.ShootWeapon -= Shoot;
    }

    /// <summary>
    /// Method that is call by the input manager to create bullets
    /// </summary>
    public override void Shoot()
    {

        RaycastHit hit;

        Vector3 spawnPosition = BulletSpawnPoint.transform.position;
        Vector3 spawnDirection = BulletSpawnPoint.transform.forward;

        if (Physics.Raycast(spawnPosition, spawnDirection, out hit, Mathf.Infinity))
        {
            destination = hit.point;
            BulletCreation.BulletCreation(spawnPosition, destination);

        }
        else
        {
            destination = spawnPosition
                + spawnDirection * BulletData.Range;
            BulletCreation.BulletCreation(spawnPosition, destination);
        }
    }
}
