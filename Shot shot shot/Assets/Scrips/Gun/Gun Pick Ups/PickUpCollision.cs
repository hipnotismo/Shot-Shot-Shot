using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scrip that take a TAG and send it to the MANAGER so that PLAYER can receive the ID of the GUN
/// </summary>
public class PickUpCollision : MonoBehaviour
{
    [SerializeField] EventMangerScriptable Manager;
    [SerializeField] List<string> TagToSend = new List<string>();
    [SerializeField] string MessageToSend;
    [SerializeField] string CanCollideTag;
    [SerializeField] GunData GunData;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideTag)
        {
            Manager.TriggerEvent(TagToSend[0], new Dictionary<string, object> { { MessageToSend, GunData.Id } });
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Manager.TriggerEvent(TagToSend[1], new Dictionary<string, object> { { MessageToSend, null } });
    }

    private void OnDestroy()
    {
        Manager.TriggerEvent(TagToSend[1], new Dictionary<string, object> { { MessageToSend, null } });
    }
}
