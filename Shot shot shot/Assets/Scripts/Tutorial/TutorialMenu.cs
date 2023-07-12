using UnityEngine;

/// <summary>
/// Sets time to 1 and de activates the TUTORIAL menu
/// </summary>
public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private GameObject TutorialPrompt;

    /// <summary>
    /// Disables the game object that hold the tutorial instructions and turns the game time to 1 
    /// </summary>
    public void HideMenu()
    {
        Time.timeScale = 1;
        TutorialPrompt.SetActive(false);
    }
}
