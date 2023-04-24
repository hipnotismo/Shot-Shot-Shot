using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public float damage = 10;
    public float range = 10;

    public Camera cam;  
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
