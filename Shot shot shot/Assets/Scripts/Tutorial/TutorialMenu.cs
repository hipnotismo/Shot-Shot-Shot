using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] GameObject TutorialPromp;

    /// <summary>
    /// disables the game object that hold the tutorial instructions and turns the game time to 1 
    /// </summary>
    public void HideMenu()
    {
        Time.timeScale = 1;
        TutorialPromp.SetActive(false);
    }
}
