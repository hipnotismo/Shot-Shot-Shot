using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GunBase : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float damage = 10;
    //[SerializeField] float range = 10;
    [SerializeField] int mode;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunpoint;

    public Camera cam;

    void Start()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);

    }

    public virtual void Shoot()
    {

    }

   
}
