using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
///  Class that holds the methods accesible from the gameplay menu
/// </summary>
public class GameplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PauseButton;

    [SerializeField] private string MenuToReturn;
    private EventSystem m_EventSystem;

    /// <summary>
    /// Subscribe to pause delegates and assigns current event system
    /// </summary>
    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;

        Pause.Activation += ActivatePause;
        Pause.DeActivation += DeactivatePause;
    }

    /// <summary>
    /// Unsubscribe to pause delegates
    /// </summary>
    private void OnDisable()
    {
        Pause.Activation -= ActivatePause;
        Pause.DeActivation -= DeactivatePause;
    }
    /// <summary>
    /// Loads main menu scene
    /// </summary>
    public void ReturnToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MenuToReturn);

    }

    /// <summary>
    /// Reloads current scene
    /// </summary>
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Exist game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();

    }

    /// <summary>
    /// Gets called by the input manager to activate the pause
    /// </summary>
    public void ActivatePause()
    {

        if (PauseMenu != null)
        {

            PauseMenu.SetActive(true);
            m_EventSystem.SetSelectedGameObject(PauseButton);

        }
        else
        {
            Debug.Log(nameof(PauseMenu) + " is null");
        }
    }

    /// <summary>
    /// Gets called by the input manager to deactivate the pause
    /// </summary>
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
