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

        if (Physics.Raycast(BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.forward, out hit, TailData.Range))
        {
            Debug.Log(hit.transform.name);
         
            ITakeDamage isHit = hit.collider.GetComponent<ITakeDamage>();
           
            BulletTrail.BulletInstance(BulletSpawnPoint.transform.position, Quaternion.identity, hit.point, hit.normal, true);

            if (isHit != null)
            {
                isHit.TakeDamage();
            }
        }
        else
        {          
           BulletTrail.BulletInstance(BulletSpawnPoint.transform.position, Quaternion.identity,hit.point, hit.normal, false);
        }
    }
}
