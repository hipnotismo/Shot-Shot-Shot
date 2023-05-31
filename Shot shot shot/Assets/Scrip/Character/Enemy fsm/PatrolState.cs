using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public ChaseState Chase;
    public bool canSeePlayer = true;
    public override EnemyState RunCurrentState()
    {
        Debug.Log("We are in patrol state");

        Debug.Log(canSeePlayer);

        if (canSeePlayer != true)
        {
            Debug.LogError("We change to chase");

            return Chase;
        }
        else
        {
            Debug.Log("Still in patrol state");

            return this;

        }
    }
}
