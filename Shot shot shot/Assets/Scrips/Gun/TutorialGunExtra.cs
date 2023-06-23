using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGunExtra : MonoBehaviour
{
    private int count = 0;
    [SerializeField] GameObject TutorialPromp;
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
