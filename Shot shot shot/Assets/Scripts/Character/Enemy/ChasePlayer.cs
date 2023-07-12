using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// takes the Player position/transform and uses the SetDestination method from nav mesh
/// </summary>
public class ChasePlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent enemy;
    [SerializeField] Transform player;

    /// <summary>
    /// Gets current nav mesh in the game object
    /// </summary>
    void Start()
    {
        enemy=GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Moves game object to the player transform
    /// </summary>
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
