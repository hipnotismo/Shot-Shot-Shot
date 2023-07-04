using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WinState : MonoBehaviour
{
    [SerializeField] private EventMangerScriptable Manager;

    [SerializeField] private string TagToReceive;
    [SerializeField] private GameObject WinFace;
    [SerializeField] private GameObject WinButton;

    private EventSystem m_EventSystem;

    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;
        Manager.StartListening(TagToReceive, WinGame);
    }

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
