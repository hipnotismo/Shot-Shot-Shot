using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Set Tutorial button in the event system
/// </summary>
public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject TutorialButton;

    private EventSystem m_EventSystem;

    /// <summary>
    /// Sets event system as the current one and calls method
    /// </summary>
    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;
        ActiveTutorialButton();

    }

    /// <summary>
    /// Sets the tutorial button as the current selected object
    /// </summary>
    private void ActiveTutorialButton()
    {
        m_EventSystem.SetSelectedGameObject(TutorialButton);

    }
}
