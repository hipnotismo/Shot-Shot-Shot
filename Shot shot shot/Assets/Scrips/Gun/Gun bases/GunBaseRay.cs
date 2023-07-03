using UnityEngine;

public class GunBaseRay : GunBase
{
    [SerializeField] GunTrailData TailData;
    [SerializeField] TrailCreation BulletTrail;

    private void OnEnable()
    {
        InputManager.ShootFromPickUp += Shoot;
    }

    private void OnDisable()
    {
        InputManager.ShootFromPickUp -= Shoot;
    }


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
