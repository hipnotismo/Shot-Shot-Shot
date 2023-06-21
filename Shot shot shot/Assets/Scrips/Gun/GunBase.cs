using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Transform gunpoint;

    public Camera cam;

    void Start()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;

    }
    void Update()
    {
       
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);

    }

    public virtual void Shoot()
    {
    }

}
