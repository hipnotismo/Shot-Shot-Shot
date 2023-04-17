using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    [Header("Setup")][SerializeField] private Rigidbody rigidBody;

    [Header("Movement")][SerializeField] private float movementSpeed = 10f;


    private Vector3 _currentMovement;

    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (!rigidBody)
        {
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
        rigidBody.velocity = _currentMovement * movementSpeed + Vector3.up * rigidBody.velocity.y;
    }

    /// <summary>
    /// moves the character by walking
    /// </summary>
    public void OnMove(InputValue context)
    {
        var movementInput = context.Get<Vector2>();
        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
