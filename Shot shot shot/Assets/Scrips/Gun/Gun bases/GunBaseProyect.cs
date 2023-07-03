using UnityEngine;
using UnityEngine.Tilemaps;

public class GunBaseProyect : GunBase
{
    [SerializeField] GunProjectileData BulletData;
    //[SerializeField] GameObject bullet;

    private Vector3 destination;

    private void OnEnable()
    {
        BulletSpawnPoint = this.transform;
        InputManager.ShootFromPickUp += Shoot;
    }

    private void OnDisable()
    {
        InputManager.ShootFromPickUp -= Shoot;
    }

    public override void Shoot()
    {

        RaycastHit hit;

        Vector3 spawnPosition = BulletSpawnPoint.transform.position;
        Vector3 spawnDirection = BulletSpawnPoint.transform.forward;

        if (Physics.Raycast(spawnPosition, spawnDirection, out hit, Mathf.Infinity))
        {
            destination = hit.point;
            CreateBullet();

        }
        else
        {
            destination = spawnPosition
                + spawnDirection * BulletData.Range;
            CreateBullet();

        }
    }

    private void CreateBullet()
    {
        GameObject projectile = Instantiate(BulletData.Bullet, BulletSpawnPoint.transform.position, Quaternion.identity);
        //TODO: Fix - Hardcoded value
        Destroy(projectile, 1f);
        //TODO: Fix - Hardcoded value
        projectile.GetComponent<Rigidbody>().AddForce((destination - projectile.transform.position).normalized * 50.0f, ForceMode.Impulse);
    }
}
