using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sends a message on collision 
/// </summary>
public class PressurePlateTrigger : MonoBehaviour
{
    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private string TagToCollideWith;
    [SerializeField] private string TagToTrigger;

    /// <summary>
    /// This function check for collision with Object caring the same tag as "TagToCollideWith"
    /// if that happen the function send a message to the manager to trigger another script with the same tag as "TagToTrigger"
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagToCollideWith)
        {
            Debug.Log(this.name + " is colliding with " + collision.gameObject.name);
            Manager.TriggerEvent(TagToTrigger, new Dictionary<string, object> { { "amount", null } });
        }
        
    }
}
