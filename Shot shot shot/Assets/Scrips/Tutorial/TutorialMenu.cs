using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] GameObject TutorialPromp;

   

    public void HideMenu()
    {
        Time.timeScale = 1;
        TutorialPromp.SetActive(false);
    }
}
