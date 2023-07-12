using UnityEngine;

/// <summary>
/// Base class for all raycast weapons
/// </summary>
public class GunBaseRay : GunBase
{
    [SerializeField] GunTrailData TailData;
    [SerializeField] TrailCreation BulletTrail;

    /// <summary>
    /// Subscribes to ShootWeapon
    /// </summary>
    private void OnEnable()
    {
        FireWeapon.ShootWeapon += Shoot;
    }

    /// <summary>
    /// Unsubscribes to ShootWeapon
    /// </summary>
    private void OnDisable()
    {
        FireWeapon.ShootWeapon -= Shoot;
    }

    /// <summary>
    /// Method that is call by the input manager to shoot bullets
    /// </summary>
    public override void Shoot()
    {
        RaycastHit hit;

        BulletTrail.ParticlePlay();
        Vector3 spawnPosition = BulletSpawnPoint.transform.position;
        Vector3 spawnDirection = BulletSpawnPoint.transform.forward;

        if (Physics.Raycast(spawnPosition, spawnDirection, out hit, TailData.Range))
        {
            Debug.Log(hit.transform.name);

            ITakeDamage isHit = hit.collider.GetComponent<ITakeDamage>();

            BulletTrail.BulletInstance(spawnPosition, Quaternion.identity, hit.point, hit.normal, true);

            if (isHit != null)
            {
                isHit.TakeDamage();
            }
        }
        else
        {

            BulletTrail.BulletInstance(spawnPosition, Quaternion.identity, spawnPosition
                + spawnDirection * TailData.Range, hit.normal, false);
        }
    }
}
