using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GoToPointState : IEnemyState
{
    public IEnemyState Behavior(MovingEnemyStateMachine enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();

        }
        if (GoToDoor(enemy))
        {
            Debug.Log("we return wandering");
            return enemy.wanderingState;
        }

        return this;
    }

    public bool GoToDoor(MovingEnemyStateMachine enemy)
    {
        enemy.navAgent.SetDestination(enemy.targetDoor.position);
        NavMeshPath navMeshPath = new NavMeshPath();

        if (enemy.navAgent.CalculatePath(enemy.targetDoor.position, navMeshPath))
        {
             enemy.navAgent.SetPath(navMeshPath);

        }
        else
        {
            Debug.Log("Path not found", enemy);
        }

        if (enemy.navAgent.remainingDistance <= enemy.arrivalThreshold)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

}
