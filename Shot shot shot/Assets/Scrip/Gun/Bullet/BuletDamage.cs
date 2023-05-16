using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BuletDamage : MonoBehaviour, ITakeDamage
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet git " + other.name);
        ITakeDamage isHit = other.GetComponent<ITakeDamage>();
        isHit.TakeDamage();

    }


    public void TakeDamage()
    {
    }
}
