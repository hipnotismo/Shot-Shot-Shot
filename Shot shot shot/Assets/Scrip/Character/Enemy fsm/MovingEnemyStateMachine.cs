using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovingEnemyStateMachine : MonoBehaviour
{
    [SerializeField] private IEnemyState currentState;

    public WanderingState wanderingState = new WanderingState();
    public GoToPointState goalState = new GoToPointState();

    public NavMeshAgent navAgent;

   public float range;

    public Transform centrePoint;

    public Transform targetDoor;

    public float arrivalThreshold = 2f;

    private void OnEnable()
    {
        currentState = goalState;
    }

    void Start()
    {
        
    }

    void Update()
    {
        currentState = currentState.Behavior(this);
    }
}
