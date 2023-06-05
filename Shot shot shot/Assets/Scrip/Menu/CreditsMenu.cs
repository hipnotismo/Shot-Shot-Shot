using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public void RetrunToMain()
    {
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("MainMenu");

    }
}
