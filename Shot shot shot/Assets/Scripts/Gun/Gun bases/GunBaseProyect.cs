using UnityEngine;

public class GunBaseProyect : GunBase
{
    [SerializeField] GunProjectileData BulletData;
    [SerializeField] CreateBullet BulletCreation;

    private Vector3 destination;

    private void OnEnable()
    {
        BulletSpawnPoint = this.transform;
        FireWeapon.ShootWeapon += Shoot;
    }

    private void OnDisable()
    {
        FireWeapon.ShootWeapon -= Shoot;
    }

    /// <summary>
    /// method that subscribes
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
