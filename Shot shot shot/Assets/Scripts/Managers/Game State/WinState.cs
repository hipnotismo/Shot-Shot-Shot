using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Manages the Win menu
/// </summary>
public class WinState : MonoBehaviour
{
    [SerializeField] private EventManagerScriptable Manager;

    [SerializeField] private string TagToReceive;
    [SerializeField] private GameObject WinFace;
    [SerializeField] private GameObject WinButton;

    private EventSystem m_EventSystem;

    /// <summary>
    /// Sets the event system as the current and stars listening for messages
    /// </summary>
    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;
        Manager.StartListening(TagToReceive, WinGame);
    }

    /// <summary>
    /// Stops listening for messages
    /// </summary>
    private void OnDisable()
    {
        Manager.StopListening(TagToReceive, WinGame);
    }

    /// <summary>
    /// Pauses the game and activates the menu related to wining the level
    /// </summary>
    private void WinGame(Dictionary<string, object> message)
    {
        WinFace.SetActive(true);
        m_EventSystem.SetSelectedGameObject(WinButton);
    }
}
