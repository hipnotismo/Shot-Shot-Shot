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
    private PickUpWeapon pickUp;

    public delegate void ShotAction();
    public static event ShotAction ShootFromPickUp;

    public delegate void MoveAction(InputValue value);
    public static event MoveAction MoveCharacter;
    //private GunBase gun;

    //hacer con eventos

    void Start()
    {
        plMov = GetComponent<CharacterMovement>();
        plLook = GetComponentInChildren<PlayerCamera>();
        pickUp = GetComponent<PickUpWeapon>();

    }

    public void OnMove(InputValue value)
    {
        //MoveCharacter(value);
        plMov.Movement(value);
    }

    public void OnLook(InputValue inputValue)
    {
        plLook.LookLogic(inputValue);
    }

    public void OnFire()
    {
        ShootFromPickUp();
    }

    public void OnPickUp()
    {
       // plMov.Interact();
    }

}
