using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] EventMangerScriptable Manager;
    /// <summary>
    /// It has to be the same tag as the one from the trigger it wants to recibe
    /// </summary>
    [SerializeField] string TagToRecibe;
    [SerializeField] Transform EndPosition;
    private Transform InitialPosition;
    private float speed = 300;

    void OnEnable()
    {
        Manager.StartListening(TagToRecibe, MoveDoorToPoint);
    }

    void OnDisable()
    {
        Manager.StopListening(TagToRecibe, MoveDoorToPoint);
    }


    void Start()
    {
        InitialPosition = GetComponent<Transform>();
    }

    
    /// <summary>
    /// Does a lerpt that moves the door to a point depending on the speed
    /// </summary>
    void MoveDoorToPoint(Dictionary<string, object> message)
    {
        DoorToOpen(InitialPosition.position, EndPosition.position,speed);
        //float step = speed * Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, point.position, step);
    }

    private IEnumerator DoorToOpen(Vector3 InitalPosition, Vector3 EndPosition, float Speed)
    {
        while (InitalPosition.y !< EndPosition.y)
        {
            InitalPosition = Vector3.Lerp(InitalPosition,EndPosition,speed);
        }
        yield return null;
    }

}
