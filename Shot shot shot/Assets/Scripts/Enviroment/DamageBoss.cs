using UnityEngine;
using System.Collections.Generic;

public class DamageBoss : MonoBehaviour, ITakeDamage
{
    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private string TagToSend;
    [SerializeField] private string MessageToSend;
    [SerializeField] private string collisionTag;

    public void TakeDamage()
    {
        Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collides with " + other.tag);
        if (other.tag == collisionTag)
        {
            Debug.Log("collides ");
            TakeDamage();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            TakeDamage();

        }
    }
}
