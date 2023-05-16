using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] Transform WeaponPoint;
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

    void Update()
    {

        //if (Input.GetKey(KeyCode.F))
        //{
        //    Drop();
        //}
    }

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


    void Equip()
    {
        Debug.Log("we are in equip");

        if (gun == null)
        {
            Debug.Log("weapon empty");

            gun = gun2;
            gun.GetComponent<Rigidbody>().isKinematic = true;

            gun.transform.position = WeaponPoint.transform.position;
            gun.transform.rotation = WeaponPoint.transform.rotation;

            gun.GetComponent<MeshCollider>().enabled = false;
            gun.transform.SetParent(WeaponPoint);
        }
       
    }


    void Shoot()
    {
        Debug.Log("We shoot");

        if (gun)
        {
            gun.Shoot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other);

        //if (Input.GetKey(KeyCode.E))
        //{
            if (other.TryGetComponent<GunBase>(out var gun))
            {

            //guns.Add(gun);
            //Equip(gun);
            gun2 = gun;
            }

           
        //}

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

    private void OnTriggerExit(Collider other)
    {
        //guns.Remove(gun);
        if (gun2 !=null)
        {
            gun2 = null;
        }
    }


}
