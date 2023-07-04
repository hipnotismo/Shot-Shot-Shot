using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private string MenuToReturn;


    private void OnValidate()
    {
        Pause.Activation += ActivatePause;
        Pause.DeActivation += DeactivatePause;
    }

    private void OnDisable()
    {
        Pause.Activation -= ActivatePause;
        Pause.DeActivation -= DeactivatePause;
    }
    public void RetrunToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MenuToReturn);

    }

    /// <summary>
    /// Reloads current scene
    /// </summary>
    public void Retry()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
    public void ExitGame()
    {
        Application.Quit();

    }

    public void ActivatePause()
    {
        Debug.Log( " we enter activate pause");

        if (PauseMenu != null)
        {
            Debug.Log(" we enter pause menu is not null");

            PauseMenu.SetActive(true);

        }
        else
        {
            Debug.Log(PauseMenu.name + " is null");
        }
    }
    public void DeactivatePause()
    {
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);

        }
        else
        {
            Debug.Log(PauseMenu.name + " is null");
        }
    }
}
