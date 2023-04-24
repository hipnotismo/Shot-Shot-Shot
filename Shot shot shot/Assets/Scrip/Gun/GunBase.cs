using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float damage = 10;
    [SerializeField] float range = 10;

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

    public void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("here");

        }
    }
}
