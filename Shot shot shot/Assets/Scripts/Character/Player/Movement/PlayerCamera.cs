using UnityEngine;

/// <summary>
/// Controls the camera so it moves with the mouse or joystick
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private Transform PlayerBody;

    [SerializeField] private Transform CamHolder;
    [SerializeField] private Transform CamWeaponLayer;

    [Header("Movement")]

    [SerializeField] private float MouseSensitivity = 100f;

    private Vector2 MouseRot;

    private float XRotation;
    
    /// <summary>
    /// Subscribes to input manager
    /// </summary>
    private void OnEnable()
    {
        InputManager.MoveCamera += CameraMovement;
    }

    /// <summary>
    /// Updates teh mouse position and player rotation
    /// </summary>
    private void Update()
    {
        var mouseX = MouseRot.x * MouseSensitivity * Time.deltaTime;
        var mouseY = MouseRot.y * MouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -70f, 70f);

        CamHolder.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        CamWeaponLayer.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// Gets and actualices the camera vector every time the InputManager detects movement
    /// </summary>
    /// <param name="inputValue"></param>
    public void CameraMovement(Vector2 inputValue)
    {
        MouseRot = inputValue;
    }
}
