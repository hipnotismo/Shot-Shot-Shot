using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform point;
    private Transform door;
    private float speed = 300;

    private void OnEnable()
    {
        //TrigerManagerTutorial.OpenDoor += OnOpenDoor;
        EventManager.StartListening("DoorOne", OnOpenDoor);

    }

    private void OnDisable()
    {
       // TrigerManagerTutorial.OpenDoor -= OnOpenDoor;
        EventManager.StopListening("DoorOne", OnOpenDoor);

    }

    void Start()
    {
        door = GetComponent<Transform>();
    }

    //TODO: TP2 - Syntax - Consistency in naming convention
    void OnOpenDoor(Dictionary<string, object> message)
    {

        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, point.position, step);
    }

}
