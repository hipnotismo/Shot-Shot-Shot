using UnityEngine;

/// <summary>
/// Controls the camero so it moves with the mouse
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private Transform playerBody;

    [SerializeField] private Transform camHolder;
    [SerializeField] private Transform camWeaponLayer;

    [Header("Movement")]

    [SerializeField] private float mouseSensitivity = 100f;

    private Vector2 mouseRot;

    private float xRotation;

    private void OnEnable()
    {
        InputManager.MoveCamera += CameraMovement;
    }

    private void Update()
    {
        var mouseX = mouseRot.x * mouseSensitivity * Time.deltaTime;
        var mouseY = mouseRot.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        camHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        camWeaponLayer.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
    /// <summary>
    /// Gets and actualices the camera vector every time the InputManager detects movement
    /// </summary>
    /// <param name="inputValue"></param>
    public void CameraMovement(Vector2 inputValue)
    {
        mouseRot = inputValue;
    }

    
}
