using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Moves Game Object to a point when a message is receive 
/// </summary>
public class OpenDoor : MonoBehaviour
{
    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private string TagToReceive;
    [SerializeField] private Transform EndPosition;
    [SerializeField] private float Speed = 300;
    private Transform InitialPosition;

    /// <summary>
    /// Stars listening for messages
    /// </summary>
    void OnEnable()
    {
        Manager.StartListening(TagToReceive, MoveDoorToPoint);

    }
    /// <summary>
    /// Stops listening for message
    /// </summary>
    void OnDisable()
    {
        Manager.StopListening(TagToReceive, MoveDoorToPoint);
    }

    /// <summary>
    /// Gets game object transform 
    /// </summary>
    void Start()
    {
        InitialPosition = GetComponent<Transform>();
    }

    
    /// <summary>
    /// Recibes a message to start a coroutine 
    /// </summary>
    void MoveDoorToPoint(Dictionary<string, object> message)
    {
        UnityEngine.Debug.Log(this.name + " is receiving the message ");

        StartCoroutine(DoorToOpen(InitialPosition.position, EndPosition.position, Speed));
     
    }

    /// <summary>
    /// Does a lerp to the game object to the EndPosition
    /// </summary>
    /// <param name="InitialPosition"></param>
    /// <param name="EndPosition"></param>
    /// <param name="Speed"></param>
    /// <returns></returns>
    private IEnumerator DoorToOpen(Vector3 InitialPosition, Vector3 EndPosition, float Speed)
    {
        UnityEngine.Debug.Log($"{name}: Moving Door from {InitialPosition} to {EndPosition} with speed {this.Speed}");

        while (transform.position.y > EndPosition.y)
        {
            transform.position = Vector3.Lerp(transform.position, EndPosition, this.Speed * Time.deltaTime);
            yield return null;
        }
    }

}
