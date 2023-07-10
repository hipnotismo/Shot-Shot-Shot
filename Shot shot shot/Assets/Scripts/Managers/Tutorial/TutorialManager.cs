using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject TutorialButton;

    private EventSystem m_EventSystem;

    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;
        ActiveTutroailButton();

    }

    private void Update()
    {
       // ActiveTutroailButton();
    }

    private void ActiveTutroailButton()
    {
        m_EventSystem.SetSelectedGameObject(TutorialButton);

    }
}
