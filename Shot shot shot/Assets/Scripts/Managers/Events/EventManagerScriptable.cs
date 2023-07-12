using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the sending of messages between classes
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObjects/Event/EventManger")]
public class EventManagerScriptable : ScriptableObject
{
    public Dictionary<string, Action<Dictionary<string, object>>> eventDictionary 
        = new Dictionary<string, Action<Dictionary<string, object>>>();

    /// <summary>
    /// stars listening for messages
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public void StartListening(string eventName, Action<Dictionary<string, object>> listener)
    {
        Action<Dictionary<string, object>> thisEvent;

        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    /// <summary>
    /// Stops listening for messages
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public void StopListening(string eventName, Action<Dictionary<string, object>> listener)
    {
        Action<Dictionary<string, object>> thisEvent;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    /// <summary>
    /// Takes an string called eventName and searches the dictionary for any event that uses that key
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="message"></param>
    public void TriggerEvent(string eventName, Dictionary<string, object> message)
    {
        Action<Dictionary<string, object>> thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(message);
        }
    }
}
