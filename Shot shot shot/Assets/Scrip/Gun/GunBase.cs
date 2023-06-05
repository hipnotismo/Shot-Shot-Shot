using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float damage = 10;
    //TODO: TP2 - Remove unused methods/variables
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
        //TODO: Fix - Bad log/Log out of context
        Debug.Log("We are in GunBase Shoot");

    }


}
