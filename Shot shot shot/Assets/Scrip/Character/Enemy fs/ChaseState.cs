using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        //TODO - Fix - Bad log/Log out of context
        Debug.Log("We are in chase state");

        return this;
    }
}
