using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public ChaseState Chase;
    public bool canSeePlayer = true;
    public override EnemyState RunCurrentState()
    {
        //TODO: Fix - Bad log/Log out of context
        Debug.Log("We are in patrol state");

        //TODO: Fix - Bad log/Log out of context
        Debug.Log(canSeePlayer);

        if (canSeePlayer != true)
        {
            //TODO: Fix - Bad log/Log out of context
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
