using UnityEngine;

[CreateAssetMenu(fileName = "GunTrailData", menuName = "ScriptableObjects/GunTrailScriptableObject", order = 2)]
public class GunTrailData : GunData
{
    [SerializeField]
    public float Range = 10;
    [SerializeField]
    public ParticleSystem ShootingSystem;
    [SerializeField]
    public ParticleSystem ImpactParticleSystem;
    [SerializeField]
    public TrailRenderer BulletTrail;
    [SerializeField]
    public LayerMask Mask;
    [SerializeField]
    public float BulletSpeed = 100;
}
