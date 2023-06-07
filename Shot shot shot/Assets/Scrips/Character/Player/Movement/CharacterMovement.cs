using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CharacterMovement : MonoBehaviour
{

    [Header("Setup")]
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform playerCamera;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;


    private Vector3 _currentMovement;

    //TODO: TP2 - Remove unused methods/variables
  //  public CinemachineVirtualCamera test;
    private Transform _target;

    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
        _target = GetComponent <Transform>();
        InputManager.MovePlayer += Movement;
    }

    private void OnDisable()
    {
        InputManager.MovePlayer -= Movement;
    }
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    void Start()
    {
        if (!rigidBody)
        {
            //TODO: Fix - Code is in Spanish or is trash code
            //<color=xxx> nos permite colorear una string
            //mas data sobre las string con $ (string interpolation):
            //https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/tokens/interpolated
            Debug.LogError($"<color=grey>{name}:</color> {nameof(rigidBody)} is null!" +
                           $"\n<color=red>Disabling this component to avoid NullReferences!</color>");
            enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (_currentMovement.magnitude >= 1f)
        {
            float targetAngle = Mathf.Atan2(_currentMovement.x, _currentMovement.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigidBody.velocity = moveDir * movementSpeed + Vector3.up * rigidBody.velocity.y;

        }

        else
        {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);


        }

    }

    /// <summary>
    /// moves the character by walking
    /// </summary>
    /// 
    //TODO: TP2 - Remove unused methods/variables
    //public void Movement(InputValue context)//cambiar a recibir vec2
    //{
    //    var movementInput = context.Get<Vector2>();

    //    _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    //}
    public void Movement(Vector2 direction)//cambiar a recibir vec2
    {
        var movementInput = direction;

        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    //TODO: TP2 - Syntax - Fix declaration order
    // Update is called once per frame
    void Update()
    {
    }
}
