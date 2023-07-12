using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that deals with the destruction of the boss
/// </summary>
public class OnBossDead : MonoBehaviour
{
    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private string TagToReceive;
    [SerializeField] string TagToSend;
    [SerializeField] string MessageToSend;

    /// <summary>
    /// Stars listening for messages
    /// </summary>
    private void OnEnable()
    {
        Manager.StartListening(TagToReceive, OnDead);
    }

    /// <summary>
    /// Stops listening for messages
    /// </summary>
    private void OnDisable()
    {
        Manager.StopListening(TagToReceive, OnDead);
    }

    /// <summary>
    /// Activates this method when the right tag is send
    /// </summary>
    /// <param name="message"></param>
    public void OnDead(Dictionary<string, object> message)
    {
        Time.timeScale = 0;

        Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });

    }
}
