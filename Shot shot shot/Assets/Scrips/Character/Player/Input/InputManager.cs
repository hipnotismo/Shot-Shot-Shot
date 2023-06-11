using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
   /// <summary>
   /// 
   /// </summary>
   
    //TODO: Documentation - Add summary
    public delegate void ShotAction();
    public static event ShotAction ShootFromPickUp;

    public delegate void PickAction();
    public static event PickAction PickUp;

    public delegate void DropAtion();
    public static event DropAtion Drop;

    public delegate void PlayerMoveAction(Vector2 dir);
    public static event PlayerMoveAction MovePlayer;

    public delegate void CameraMoveAction(Vector2 dir);
    public static event CameraMoveAction MoveCamera;

    public delegate void PauseAction();
    public static event PauseAction Pause;

    public delegate void ResumeAction();
    public static event ResumeAction Resume;

    private bool IsPause = false;

    //TODO: TP2 - Remove unused methods/variables
    void Start()
    {

    }

    public void OnMove(InputValue context)//InputValue context
    {
        var movementInput = context.Get<Vector2>();
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
