using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: TP2 - Remove unused methods/variables/classes
public class Triggerinput : MonoBehaviour
{

    Dictionary<string, Action> Tag_dict =
                      new Dictionary<string, Action>();

    //TODO: TP2 - Remove unused methods/variables
    private void OnValidate()
    {
       // TutorialGunExtra.Trigger += EnterPause;

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
