using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] Transform parent;

    void Start()
    {
        gun.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Fix - Old input manager
        if (Input.GetKey(KeyCode.F))
        {
            Drop();
        }
    }

    void Drop()
    {
        parent.DetachChildren();
        gun.transform.eulerAngles = new Vector3(gun.transform.position.x, gun.transform.position.z, gun.transform.position.y);
        gun.GetComponent<Rigidbody>().isKinematic = false;
        gun.GetComponent<MeshCollider>().enabled = true;
    }

    void Equip()
    {
        gun.GetComponent <Rigidbody>().isKinematic = true;

        gun.transform.position = parent.transform.position;
        gun.transform.rotation = parent.transform.rotation;

        gun.GetComponent<MeshCollider>().enabled = false;
        gun.transform.SetParent(parent);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: Fix - Bad log/Log out of context
        Debug.Log("Colides");

        //TODO: Fix - Hardcoded value
        if (other.gameObject.tag == "Player")
        {
            //TODO: Fix - Bad log/Log out of context
            Debug.Log("is player");

            //TODO: Fix - Old input manager
            if (Input.GetKey(KeyCode.E))
            {
                //TODO: Fix - Bad log/Log out of context
                Debug.Log("here");

                Equip();
            }
        }
    }
}
