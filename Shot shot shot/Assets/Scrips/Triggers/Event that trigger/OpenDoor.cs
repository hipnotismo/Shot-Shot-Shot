using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] EventMangerScriptable Manager;
    /// <summary>
    /// It has to be the same tag as the one from the trigger it wants to recibe
    /// </summary>
    [SerializeField] private string TagToReceive;
    [SerializeField] private Transform EndPosition;
    [SerializeField] private float speed = 300;
    private Transform InitialPosition;

    void OnEnable()
    {
        Manager.StartListening(TagToReceive, MoveDoorToPoint);
    }

    void OnDisable()
    {
        Manager.StopListening(TagToReceive, MoveDoorToPoint);
    }


    void Start()
    {
        InitialPosition = GetComponent<Transform>();
    }

    
    /// <summary>
    /// Does a lerp that moves the door to a point depending on the speed
    /// </summary>
    void MoveDoorToPoint(Dictionary<string, object> message)
    {
        UnityEngine.Debug.Log(this.name + " is recibing the message ");

        StartCoroutine(DoorToOpen(InitialPosition.position, EndPosition.position, speed));
     
    }

    private IEnumerator DoorToOpen(Vector3 InitalPosition, Vector3 EndPosition, float Speed)
    {
        UnityEngine.Debug.Log($"{name}: Moving Door from {InitalPosition} to {EndPosition} with speed {speed}");

        while (transform.position.y > EndPosition.y)
        {
            transform.position = Vector3.Lerp(transform.position, EndPosition,speed * Time.deltaTime);
            yield return null;
        }
    }

}
