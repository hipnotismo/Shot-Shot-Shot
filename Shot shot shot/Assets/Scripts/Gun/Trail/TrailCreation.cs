using System.Collections;
using UnityEngine;

/// <summary>
/// Creation of trails
/// </summary>
public class TrailCreation : MonoBehaviour
{
    [SerializeField] GunTrailData TailData;

    /// <summary>
    /// Plays ParticleSystem
    /// </summary>
    public void ParticlePlay()
    {
        TailData.ShootingSystem.Play();

    }

    /// <summary>
    /// Instantiates a particle trail base on the pass parameters
    /// </summary>
    /// <param name="BulletSpawnPoint"></param>
    /// <param name="identity"></param>
    /// <param name="Point"></param>
    /// <param name="Normal"></param>
    /// <param name="MadeImpact"></param>
    public void BulletInstance(Vector3 BulletSpawnPoint, Quaternion identity, Vector3 Point, Vector3 Normal, bool MadeImpact)
    {
        TrailRenderer trail = Instantiate(TailData.BulletTrail, BulletSpawnPoint, identity);

        StartCoroutine(SpawnTrail(trail, Point, Normal, MadeImpact));
    }

    /// <summary>
    /// Takes the previous trail and makes it move until it reaches its destination 
    /// </summary>
    /// <param name="Trail"></param>
    /// <param name="HitPoint"></param>
    /// <param name="HitNormal"></param>
    /// <param name="MadeImpact"></param>
    /// <returns></returns>
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
