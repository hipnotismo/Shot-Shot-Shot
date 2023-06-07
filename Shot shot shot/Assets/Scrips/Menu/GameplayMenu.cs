using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

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
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("MainMenu");

    }

    //TODO: Documentation - Add summary
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
        PauseMenu.SetActive(true);
    }
    public void DeactivatePause()
    {
        PauseMenu.SetActive(false);
    }
}
