using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Stops the game and sends a message that activates the WIN menu
/// </summary>
public class WinActivation : MonoBehaviour
{
    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private string TagToSend;
    [SerializeField] private string MessageToSend;
    [SerializeField] private string CanCollideWithTag;

    /// <summary>
    /// Once the game object with the correct tag collides with this one the scrip sets the time to cero and sends a 
    /// message to activate the WIN ui.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideWithTag)
        {
            Time.timeScale = 0;
            Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });
        }
    }
}
