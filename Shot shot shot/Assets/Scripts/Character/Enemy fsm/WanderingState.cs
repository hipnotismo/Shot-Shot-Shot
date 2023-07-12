using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Enemy states that creates a random point and moves the game object
/// </summary>
public class WanderingState : IEnemyState
{
    /// <summary>
    /// Behavior for the enemy state interface
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    public IEnemyState Behavior(MovingEnemyStateMachine enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();

        }

        DoWander(enemy);

        return this;
    }

    /// <summary>
    /// Moves the game object from one point to the other and once that is done it get a new random point to move towards
    /// </summary>
    /// <param name="enemy"></param>
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

    /// <summary>
    /// Get a new random point inside a range
    /// </summary>
    /// <param name="center"></param>
    /// <param name="range"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
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
