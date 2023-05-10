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
        SceneManager.LoadScene("MainMenu");

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
