using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class EnemyBase : MonoBehaviour, ITakeDamage
{
    [SerializeField] OpenDoor OptionalDoor;
    [SerializeField] DestroyObject DestroyObject;

    //TODO: TP2 - Remove unused methods/variables
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        //TODO: TP2 - SOLID
        if (OptionalDoor != null)
        {
            OptionalDoor.OpDoor();

        }

        //TODO: Fix - Why not just call Destroy(DestroyObject.gameObject) ?
        if (DestroyObject!=null)
        {
            DestroyObject.destroyObject();
        }
        //TODO - Fix - Hardcoded value
        if (gameObject.tag != "boss")
        {
            Destroy(gameObject);

        }
    }

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    private void OnTriggerEnter(Collider other)
    {
        //TODO: TP2 - Remove unused methods/variables
        //Debug.Log("here");
        //Debug.Log(other.transform.name);
        //ITakeDamage isHit = other.GetComponent<ITakeDamage>();
        //isHit.TakeDamage();

        //TODO - Fix - Hardcoded value
        if (other.tag == "bullet")
        {
            TakeDamage();
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //TODO - Fix - Bad log/Log out of context
            Debug.Log("here");
            //BUG: Could trigger a NullReferenceException
            ITakeDamage isHit = collision.gameObject.GetComponent<ITakeDamage>();

            isHit.TakeDamage();
        }

    }
}
