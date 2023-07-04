using UnityEngine;
using UnityEngine.AI;

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
