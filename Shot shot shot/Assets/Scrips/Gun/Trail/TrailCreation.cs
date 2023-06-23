using System.Collections;
using UnityEngine;

public class TrailCreation : MonoBehaviour
{
    [SerializeField] GunTrailData TailData;

    public void ParticlePlay()
    {
        TailData.ShootingSystem.Play();

    }

    public void BulletInstance(Vector3 BulletSpawnPoint, Quaternion identity, Vector3 Point, Vector3 Normal, bool MadeImpact)
    {
        TrailRenderer trail = Instantiate(TailData.BulletTrail, BulletSpawnPoint, identity);

        StartCoroutine(SpawnTrail(trail, Point, Normal, MadeImpact));
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact)
    {
      
        Vector3 startPosition = Trail.transform.position;
        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float remainingDistance = distance;

        while (remainingDistance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (remainingDistance / distance));

            remainingDistance -= TailData.BulletSpeed * Time.deltaTime;

            yield return null;
        }
        Trail.transform.position = HitPoint;
        if (MadeImpact)
        {
            Instantiate(TailData.ImpactParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));
        }

        Destroy(Trail.gameObject, Trail.time);
    }
}
