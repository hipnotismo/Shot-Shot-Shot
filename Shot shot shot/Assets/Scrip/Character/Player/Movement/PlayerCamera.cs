using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void OnValidate()
    {
        InputManager.MoveCamera += LookLogic;
    }

    void Update()
    {
        var mouseX = mouseRot.x * mouseSensitivity * Time.deltaTime;
        var mouseY = mouseRot.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        camHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        camWeaponLayer.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    //TODO: TP2 - Syntax - Consistency in naming convention
    public void LookLogic(Vector2 inputValue)
    {
        mouseRot = inputValue;
    }

    
}
