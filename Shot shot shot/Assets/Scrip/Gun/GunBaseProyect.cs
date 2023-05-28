using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseProyect : GunBase
{    
    [SerializeField] GameObject bullet;

    private Vector3 destination;

    void Start()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;

    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);

    }

    public override void Shoot()
    {
        Debug.Log("Shooting instances");

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            destination = hit.point;
            CreateBullet();

        }
        else
        {
            destination = ray.GetPoint(1000);
            CreateBullet();

        }
    }

    private void CreateBullet()
    {
        GameObject proyectile = Instantiate(bullet, cam.transform.position, Quaternion.identity);
        Destroy(proyectile, 1f);
        proyectile.GetComponent<Rigidbody>().AddForce((destination - proyectile.transform.position).normalized * 50.0f, ForceMode.Impulse);
    }
}
