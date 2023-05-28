using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGunExtra : MonoBehaviour
{
    private int count = 0;
    [SerializeField] GameObject TutorialPromp;

    public delegate void TriggerWall();
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
            TutorialPromp.SetActive(true);
            Time.timeScale = 0;
            count++;
        }
      
    }
}
