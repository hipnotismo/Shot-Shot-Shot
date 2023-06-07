using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] Transform WeaponPoint;
    //TODO: Fix - Gun1, Gun2?
    [SerializeField] GunBase gun;
    [SerializeField] GunBase gun2;

    private List<GunBase> guns = new List<GunBase>();

    private void OnEnable()
    {
        InputManager.ShootFromPickUp += Shoot;
        InputManager.PickUp += Equip;
        InputManager.Drop += Drop;
    }

    private void OnDisable()
    {
        InputManager.ShootFromPickUp -= Shoot;
        InputManager.PickUp -= Equip;
        InputManager.Drop -= Drop;
    }

    //TODO: TP2 - Remove unused methods/variables
    void Update()
    {

       
    }

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    void Drop()
    {
        if (gun != null)
        {
            WeaponPoint.DetachChildren();
            gun.transform.eulerAngles = new Vector3(gun.transform.position.x, gun.transform.position.z, gun.transform.position.y);
            gun.GetComponent<Rigidbody>().isKinematic = false;
            gun.GetComponent<MeshCollider>().enabled = true;
            gun = null;
        }

    }


    //TODO: Documentation - Add summary
    void Equip()
    {

        if (gun == null && gun2 != null)
        {

            gun = gun2;
            gun.GetComponent<Rigidbody>().isKinematic = true;

            gun.transform.position = WeaponPoint.transform.position;
            gun.transform.rotation = WeaponPoint.transform.rotation;

            gun.GetComponent<MeshCollider>().enabled = false;
            gun.transform.SetParent(WeaponPoint);
            int WeaponLayer = LayerMask.NameToLayer("weapon");

            gun.gameObject.layer = WeaponLayer;

            foreach (Transform child in gun.transform)
            {
                child.gameObject.layer = WeaponLayer;
            }
        }

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

        if (other.TryGetComponent<GunBase>(out var gun))
        {


            gun2 = gun;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (gun2 != null)
        {
            gun2 = null;
        }
    }


}
