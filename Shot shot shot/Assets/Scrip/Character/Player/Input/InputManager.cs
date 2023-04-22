using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;

public class InputManager : MonoBehaviour
{
    [Header("References")]
    private CharacterMovement plMov;
    private PlayerCamera plLook;

    void Start()
    {
        plMov = GetComponent<CharacterMovement>();
        plLook = GetComponentInChildren<PlayerCamera>();

    }

    public void OnMove(InputValue value)
    {
        plMov.Movement(value);
    }

    public void OnLook(InputValue inputValue)
    {
        plLook.LookLogic(inputValue);
    }

}
