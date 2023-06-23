using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Transform BulletSpawnPoint;

    public Camera cam;

    void Start()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;

    }

    public virtual void Shoot()
    {
    }

}
