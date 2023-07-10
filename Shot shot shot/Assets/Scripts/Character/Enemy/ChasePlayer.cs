using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// takes the Player positon/transform and uses the SetDestination method from navmesh
/// </summary>
public class ChasePlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent enemy;
    [SerializeField] Transform player;

    void Start()
    {
        enemy=GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
