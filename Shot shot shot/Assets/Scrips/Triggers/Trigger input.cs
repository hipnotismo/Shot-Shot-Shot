using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: TP2 - Remove unused methods/variables/classes
public class Triggerinput : MonoBehaviour
{

    Dictionary<string, Action> Tag_dict =
                      new Dictionary<string, Action>();

    Dictionary<string, object> Tag_dicts =
                      new Dictionary<string, object>();

    static Dictionary<string, Action<Dictionary<string, object>>> eventDictionary;

    //new Dictionary<string, object> { { "amount", 1 } }

    //TODO: TP2 - Remove unused methods/variables
    private void OnValidate()
    {
        eventDictionary = new Dictionary<string, Action<Dictionary<string, object>>>();

        // TutorialGunExtra.Trigger += EnterPause;

    }


    public static void StartListening(string eventName, Action<Dictionary<string, object>> listener)
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Fix - Hardcoded value
        if (Tag_dict.ContainsKey("Gun") == true)
        {
            //TODO: Fix - Bad log/Log out of context
            Console.WriteLine("Key is found...!!");
        }
    }

    void AddKey(string key)
    {

    }
}
