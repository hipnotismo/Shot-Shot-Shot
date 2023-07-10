using UnityEngine;
using UnityEngine.AI;

public class WanderingState : IEnemyState
{
    public IEnemyState Behavior(MovingEnemyStateMachine enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();

        }

        DoWander(enemy);

        return this;
    }

    public void DoWander(MovingEnemyStateMachine enemy)
    {
        if (enemy.navAgent.remainingDistance <= enemy.navAgent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(enemy.centrePoint.position, enemy.range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                enemy.navAgent.SetDestination(point);
            }
        }
    }

    //TODO: Fix - Repeated code
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        {
          
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
