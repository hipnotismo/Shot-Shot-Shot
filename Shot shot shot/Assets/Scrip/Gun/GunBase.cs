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
    [SerializeField] float range = 10;
    [SerializeField] int mode;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunpoint;

    public Camera cam;

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

    public void Shoot()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if (mode == 1)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Debug.Log("here");
                ITakeDamage isHit = hit.collider.GetComponent<ITakeDamage>();

                isHit.TakeDamage();
            }
        }
        else
        {
            Debug.Log("Shooting instances");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                destination = hit.point;
                Debug.Log(destination);
                CreateBullet();

            }
            else
            {
                destination = ray.GetPoint(1000);
                CreateBullet();
            }
        }
    }

    private void CreateBullet()
    {
        GameObject proyectile = Instantiate(bullet, cam.transform.position, Quaternion.identity);
        Destroy(proyectile, 1f);
        proyectile.GetComponent<Rigidbody>().AddForce((destination - proyectile.transform.position).normalized * 50.0f, ForceMode.Impulse);
    }
}
