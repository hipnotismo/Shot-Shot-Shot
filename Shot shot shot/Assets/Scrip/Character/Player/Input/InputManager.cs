using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InputManager : MonoBehaviour
{
    [Header("References")]
    private CharacterMovement plMov;
    private PlayerCamera plLook;
    private PickUpWeapon pickUp;

    public delegate void ShotAction();
    public static event ShotAction ShootFromPickUp;

    public delegate void PlayerMoveAction(Vector2 dir);
    public static event PlayerMoveAction MovePlayer;

    public delegate void CameraMoveAction(Vector2 dir);
    public static event CameraMoveAction MoveCamera;

    //private GunBase gun;

    //hacer con eventos

    void Start()
    {
       // plMov = GetComponent<CharacterMovement>();
        //plLook = GetComponentInChildren<PlayerCamera>();
        //pickUp = GetComponent<PickUpWeapon>();

    }

    public void OnMove(InputValue context)//InputValue context
    {
        var movementInput = context.Get<Vector2>();
        MovePlayer(movementInput);
        //plMov.Movement(movementInput);
    }

    public void OnLook(InputValue inputValue)
    {
        var cameraInput = inputValue.Get<Vector2>();
        MoveCamera(cameraInput);
       // plLook.LookLogic(inputValue);
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
