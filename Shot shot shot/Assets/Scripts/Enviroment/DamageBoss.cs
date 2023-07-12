using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Class that deals with the boss weak points
/// </summary>
public class DamageBoss : MonoBehaviour, ITakeDamage
{
    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private string TagToSend;
    [SerializeField] private string MessageToSend;
    [SerializeField] private string collisionTag;

    /// <summary>
    /// Damage interface, sends a message and destroys the current game object
    /// </summary>
    public void TakeDamage()
    {
        Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });
        Destroy(gameObject);
    }

    /// <summary>
    /// Activates the damage interface when an object with the correct tag collides with it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == collisionTag)
        {
            TakeDamage();
        }

    }

    /// <summary>
    ///Activates the damage interface when an object with the correct tag collides with it
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            TakeDamage();
        }
    }
}
