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

        //TODO: Fix - Bad log/Log out of context
        Debug.Log("Inside wandering state");
        return this;
    }

    public void DoWander(MovingEnemyStateMachine enemy)
    {
        if (enemy.navAgent.remainingDistance <= enemy.navAgent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(enemy.centrePoint.position, enemy.range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                enemy.navAgent.SetDestination(point);
            }
        }
    }

    //TODO: Fix - Repeated code
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
