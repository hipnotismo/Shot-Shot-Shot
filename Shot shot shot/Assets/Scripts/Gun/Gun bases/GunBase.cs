using UnityEngine;

/// <summary>
/// Base class shared by all guns 
/// </summary>
public class GunBase : MonoBehaviour
{
    public Transform BulletSpawnPoint;

    public Camera cam;

    /// <summary>
    /// Sets rigid body as kinematic
    /// </summary>
    void Start()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;

    }

    /// <summary>
    /// Empty virtual method for the inheriting classes to fill
    /// </summary>
    public virtual void Shoot()
    {
    }

}
