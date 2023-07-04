using System.Collections.Generic;
using UnityEngine;

public class PresurePlateTrigger : MonoBehaviour
{
    [SerializeField] EventMangerScriptable Manager;
    [SerializeField] string TagToCollideWith;
    [SerializeField] string TagToTrigger;

    /// <summary>
    /// This function check for collision with Object carring the same tag as "TagToCollideWith"
    /// if that happen the fuction send a message to the manager to tigger another script with the same tag as "TagToTrigger"
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
