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
        if (other.tag == "Player")
        {
            //OpenDoor();
            door.OpDoor();

        }

    }
}
