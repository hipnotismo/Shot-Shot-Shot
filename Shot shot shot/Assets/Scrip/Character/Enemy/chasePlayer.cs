using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chasePlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent enemy;
    [SerializeField] Transform player;

    void Start()
    {
        enemy=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
