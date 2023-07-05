using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{
    [SerializeField] private EventMangerScriptable Manager;
    [SerializeField] private string TagToReceive;
    [SerializeField] string TagToSend;
    [SerializeField] string MessageToSend;

    private void OnEnable()
    {
        Manager.StartListening(TagToReceive, OnDead);
    }

    private void OnDisable()
    {
        Manager.StopListening(TagToReceive, OnDead);
    }

    public void OnDead(Dictionary<string, object> message)
    {
        Time.timeScale = 0;

        Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });

    }
}
