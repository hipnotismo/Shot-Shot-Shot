using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerinput : MonoBehaviour
{

    Dictionary<string, Action> Tag_dict =
                      new Dictionary<string, Action>();

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
        if (Tag_dict.ContainsKey("Gun") == true)
        {
            Console.WriteLine("Key is found...!!");
        }
    }

    void AddKey(string key)
    {

    }
}
