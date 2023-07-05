using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Class to control the boss health
/// </summary>
public class BossHealth : MonoBehaviour
{
    [SerializeField] private EventMangerScriptable Manager;
    [SerializeField] private string TagToReceive;
    [SerializeField] private string TagToSend;
    [SerializeField] string MessageToSend;

    [SerializeField] private int BossTotalHealth;
    private void OnEnable()
    {
        Manager.StartListening(TagToReceive, LossBossHealth);
    }

    private void OnDisable()
    {
        Manager.StopListening(TagToReceive, LossBossHealth);
    }

    /// <summary>
    /// Normally call from another class or method to reduce the bossTotalHealt and check if it less than zero to destroy the object and activate the win screen.
    /// </summary>
    public void LossBossHealth(Dictionary<string, object> message)
    {
        BossTotalHealth--;
        Debug.Log(BossTotalHealth);
        if (BossTotalHealth < 1)
        {
            Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });
            Destroy(gameObject);
        }
    }
}
