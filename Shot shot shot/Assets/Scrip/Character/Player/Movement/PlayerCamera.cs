using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private Transform playerBody;

    [SerializeField] private Transform camHolder;

    [Header("Movement")]

    [SerializeField] private float mouseSensitivity = 100f;

    private Vector2 mouseRot;

    private float xRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = mouseRot.x * mouseSensitivity * Time.deltaTime;
        var mouseY = mouseRot.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        camHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void LookLogic(InputValue inputValue)
    {
        mouseRot = inputValue.Get<Vector2>();
    }

    
}
