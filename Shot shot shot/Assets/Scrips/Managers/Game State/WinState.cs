using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WinState : MonoBehaviour
{


    [SerializeField] private GameObject WinFace;
    [SerializeField] private GameObject WinButton;

    private EventSystem m_EventSystem;

    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;
        WinActivation.WinGame += WinGame;
    }

    private void OnDisable()
    {
        WinActivation.WinGame -= WinGame;
    }

    /// <summary>
    /// Pauses the game and activates the menu related to wining the level
    /// </summary>
    private void WinGame()
    {
        WinFace.SetActive(true);
        m_EventSystem.SetSelectedGameObject(WinButton);


    }
}
