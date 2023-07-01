using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// All delegates that get called after input is detected
    ///  -ShotAction: event related to the left mouse input
    ///  -PickAction: event related to the keyboard input, E key
    ///  -DropAction: event related to the keyboard input, F key
    ///  -PlayerMoveAction: event related to the keyboard input, WASD keys
    ///  -CameraMoveAction: event related to the mouse movement
    ///  -PauseAction  and ResumeAction: event related to the keyboard input, P key
    /// </summary>

    public delegate void ShotAction();
    public static event ShotAction ShootFromPickUp;

    public delegate void PickAction();
    public static event PickAction PickUp;

    public delegate void DropAction();
    public static event DropAction Drop;

    public delegate void PlayerMoveAction(Vector2 dir);
    public static event PlayerMoveAction MovePlayer;

    public delegate void CameraMoveAction(Vector2 dir);
    public static event CameraMoveAction MoveCamera;

    public delegate void PauseAction();
    public static event PauseAction Pause;

    public delegate void ResumeAction();
    public static event ResumeAction Resume;

    private bool IsPause = false;
    public void OnMove(InputValue inputValue)
    {
        var movementInput = inputValue.Get<Vector2>();
        MovePlayer(movementInput);
    }

    public void OnLook(InputValue inputValue)
    {

        var cameraInput = inputValue.Get<Vector2>();
        MoveCamera(cameraInput);
    }

    public void OnFires()
    {
        ShootFromPickUp();
    }

    public void OnPickUp()
    {
        PickUp();
    }

    public void OnDrop()
    {
        Drop();
    }

    public void OnPause()
    {
        if (IsPause == false)
        {

            Pause();
            IsPause = true;
        }
        else
        {

            Resume();
            IsPause = false;

        }
    }
}
