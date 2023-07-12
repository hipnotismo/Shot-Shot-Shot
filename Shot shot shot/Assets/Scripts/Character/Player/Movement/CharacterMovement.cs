using UnityEngine;

/// <summary>
/// Controls the movement of the character´s rigidBody
/// </summary>
public class CharacterMovement : MonoBehaviour
{

    [Header("Setup")]
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform playerCamera;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;


    private Vector3 _currentMovement;

    /// <summary>
    /// Gets teh current rigidbody and subscribes to input manager
    /// </summary>
    private void OnEnable()
    {
        rigidBody ??= GetComponent<Rigidbody>();
        InputManager.MovePlayer += Movement;
    }

    /// <summary>
    /// Unsubscribes to the input manager
    /// </summary>
    private void OnDisable()
    {
        InputManager.MovePlayer -= Movement;
    }

    /// <summary>
    /// Checks if there is a rigidbody
    /// </summary>
    private void Start()
    {
        if (!rigidBody)
        {            
            Debug.LogError($"<color=grey>{name}:</color> {nameof(rigidBody)} is null!" +
                           $"\n<color=red>Disabling this component to avoid NullReferences!</color>");
            enabled = false;
        }
    }

    /// <summary>
    /// Detects if there is movement 
    /// </summary>
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
    /// moves the character after the InputManager detects input
    /// </summary>
    public void Movement(Vector2 direction)
    {
        var movementInput = direction;

        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }
}
