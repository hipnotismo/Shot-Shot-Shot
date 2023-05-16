using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class EnemyBase : MonoBehaviour, ITakeDamage
{
    [SerializeField] OpenDoor OptionalDoor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (OptionalDoor != null)
        {
            OptionalDoor.OpDoor();

        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        //Debug.Log(other.transform.name);
        //ITakeDamage isHit = other.GetComponent<ITakeDamage>();
        //isHit.TakeDamage();

        if (other.tag == "bullet")
        {
            TakeDamage();
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("here");
            ITakeDamage isHit = collision.gameObject.GetComponent<ITakeDamage>();
            Debug.Log(isHit);

            isHit.TakeDamage();
        }

    }
}
