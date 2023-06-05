using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BuletDamage : MonoBehaviour, ITakeDamage
{
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
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


    //TODO: TP2 - SOLID
    public void TakeDamage()
    {
    }
}
