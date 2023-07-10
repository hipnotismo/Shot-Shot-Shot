using UnityEngine;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverFace;
    [SerializeField] private GameObject GameOverButton;

    private EventSystem m_EventSystem;

    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;
        PlayerLife.GameOver += GamerOver;
    }

    private void OnDisable()
    {
        PlayerLife.GameOver -= GamerOver;
    }

    /// <summary>
    /// Pauses the game and activates the menu related to game over
    /// </summary>
    private void GamerOver()
    {
        Time.timeScale = 0;
        GameOverFace.SetActive(true);
        m_EventSystem.SetSelectedGameObject(GameOverButton);


    }
}
