using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    public void RetrunToMain()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
