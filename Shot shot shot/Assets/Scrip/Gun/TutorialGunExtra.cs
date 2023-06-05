using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGunExtra : MonoBehaviour
{
    private int count = 0;
    [SerializeField] GameObject TutorialPromp;

    public delegate void TriggerWall();
    //TODO: TP2 - Remove unused methods/variables
    public static event TriggerWall Trigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (count == 0)
        {
            //TODO: TP2 - SOLID
            TutorialPromp.SetActive(true);
            Time.timeScale = 0;
            count++;
        }
      
    }
}
