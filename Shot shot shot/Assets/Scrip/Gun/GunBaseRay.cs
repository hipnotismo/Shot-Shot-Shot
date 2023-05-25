using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseRay :  GunBase
{
    //[Header("Stats")]
    //[SerializeField] private float damage = 10;
    [SerializeField] float range = 10;

    //[SerializeField] Camera cam;

    private Vector3 destination;

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

    public override void Shoot()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
       
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Debug.Log("here");
                ITakeDamage isHit = hit.collider.GetComponent<ITakeDamage>();

                isHit.TakeDamage();
            }
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("gunnnnnnn");
    }
}
