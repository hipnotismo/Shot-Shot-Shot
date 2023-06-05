using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigermanagertutorial : MonoBehaviour
{
    public delegate void OpenAction();
    public static event OpenAction OpenDoor;

    [SerializeField] OpenDoor door;

    private void OnTriggerEnter(Collider other)
    {
        //TODO: Fix - Hardcoded value
        if (other.tag == "Player")
        {
            //TODO: TP2 - Remove unused methods/variables
            //OpenDoor();
            door.OpDoor();

        }

    }
}
