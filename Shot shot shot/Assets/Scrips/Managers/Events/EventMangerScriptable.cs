using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Event/EventManger")]
public class EventMangerScriptable : ScriptableObject
{
    public Dictionary<string, Action<Dictionary<string, object>>> eventDictionary 
        = new Dictionary<string, Action<Dictionary<string, object>>>();

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

    public void StopListening(string eventName, Action<Dictionary<string, object>> listener)
    {
        Action<Dictionary<string, object>> thisEvent;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    public void TriggerEvent(string eventName, Dictionary<string, object> message)
    {
        Action<Dictionary<string, object>> thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(message);
        }
    }
}
