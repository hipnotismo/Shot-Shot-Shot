using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scrip that take a TAG and send it to the MANAGER so that PLAYER can receive the ID of the GUN
/// </summary>
public class PickUpCollision : MonoBehaviour
{
    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private List<string> TagToSend = new List<string>();
    [SerializeField] private string MessageToSend;
    [SerializeField] private string CanCollideTag;
    [SerializeField] private GunData GunData;


    /// <summary>
    /// Triggers event on collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideTag)
        {
            Manager.TriggerEvent(TagToSend[0], new Dictionary<string, object> { { MessageToSend, GunData.Id } });
        }
    }

    /// <summary>
    /// Triggers event on exit
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        Manager.TriggerEvent(TagToSend[1], new Dictionary<string, object> { { MessageToSend, null } });
    }

    /// <summary>
    /// Triggers event on destruction
    /// </summary>
    private void OnDestroy()
    {
        Manager.TriggerEvent(TagToSend[1], new Dictionary<string, object> { { MessageToSend, null } });
    }
}
