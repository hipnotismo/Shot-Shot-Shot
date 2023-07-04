using UnityEngine;
using System.Collections.Generic;

public class DamageBoss : MonoBehaviour, ITakeDamage
{
    [SerializeField] EventMangerScriptable Manager;
    [SerializeField] string TagToSend;
    [SerializeField] string MessageToSend;
    [SerializeField] private BossHealth boss;
    [SerializeField] private string collisionTag;

    public void TakeDamage()
    {
        Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });

        boss.LossBossHealth();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == collisionTag)
        {
            TakeDamage();
        }

    }
}
