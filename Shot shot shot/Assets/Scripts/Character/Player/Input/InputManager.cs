using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class that controls input
/// </summary>
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

    public delegate void ShootAction();
    public static event ShootAction ShootFromPickUp;

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

    /// <summary>
    /// Detects movement 
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnMove(InputValue inputValue)
    {
        var movementInput = inputValue.Get<Vector2>();
        MovePlayer(movementInput);
    }

    /// <summary>
    /// Detects camera movement
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnLook(InputValue inputValue)
    {

        var cameraInput = inputValue.Get<Vector2>();
        MoveCamera(cameraInput);
    }
    
    /// <summary>
    /// Detects fire input
    /// </summary>
    public void OnFires()
    {
        ShootFromPickUp();
    }


    /// <summary>
    /// Detects pick up input
    /// </summary>
    public void OnPickUp()
    {
        PickUp();
    }

    /// <summary>
    /// Detects drop input
    /// </summary>
    public void OnDrop()
    {
        Drop();
    }

    /// <summary>
    /// Detects pause input
    /// </summary>
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
