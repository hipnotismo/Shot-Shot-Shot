using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] Transform WeaponPoint;
    [SerializeField] GunBase gun;
    [SerializeField] GunBase gun2;


    private void OnEnable()
    {
        InputManager.ShootFromPickUp += Shoot;
    }

    private void OnDisable()
    {
        InputManager.ShootFromPickUp -= Shoot;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.F))
        {
            Drop();
        }
    }

    void Drop()
    {
        WeaponPoint.DetachChildren();
        gun.transform.eulerAngles = new Vector3(gun.transform.position.x, gun.transform.position.z, gun.transform.position.y);
        gun.GetComponent<Rigidbody>().isKinematic = false;
        gun.GetComponent<MeshCollider>().enabled = true;
        gun = null;

    }


    void Equip(GunBase temp)
    {
        gun = temp;
        gun.GetComponent<Rigidbody>().isKinematic = true;

        gun.transform.position = WeaponPoint.transform.position;
        gun.transform.rotation = WeaponPoint.transform.rotation;

        gun.GetComponent<MeshCollider>().enabled = false;
        gun.transform.SetParent(WeaponPoint);
    }

    void Shoot()
    {
        if (gun)
        {
            gun.Shoot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colides");

        if (Input.GetKey(KeyCode.E))
        {
            if (other.TryGetComponent<GunBase>(out var gun))
            {
                Equip(gun);
            }
        }

        //if (other.gameObject.tag == "Gun")
        //{
        //    Debug.Log("is Gun");

        //    if (Input.GetKey(KeyCode.E))
        //    {
        //        Debug.Log("here");

        //        Equip(other.gameObject);
        //    }
        //}
    }
}
