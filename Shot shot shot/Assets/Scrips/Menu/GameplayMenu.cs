using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private string MenuToReturn;


    private void OnEnable()
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

        if (PauseMenu != null)
        {

            PauseMenu.SetActive(true);

        }
        else
        {
            Debug.Log(nameof(PauseMenu) + " is null");
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
            Debug.Log(nameof(PauseMenu) + " is null");
        }
    }
}
