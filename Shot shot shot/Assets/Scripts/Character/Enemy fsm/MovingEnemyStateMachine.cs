using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Enemy state machine
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class MovingEnemyStateMachine : MonoBehaviour
{
    [SerializeField] private IEnemyState currentState;

    public WanderingState wanderingState = new WanderingState();

    public NavMeshAgent navAgent;

    public float range;

    public Transform centrePoint;

    /// <summary>
    /// Sets the first state
    /// </summary>
    private void OnEnable()
    {
        currentState = wanderingState;
    }

    /// <summary>
    /// Updates the behavior of the current state
    /// </summary>
    private void Update()
    {
        currentState = currentState.Behavior(this);
    }
}
