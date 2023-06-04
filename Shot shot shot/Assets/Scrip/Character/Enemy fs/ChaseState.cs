using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        Debug.Log("We are in chase state");

        return this;
    }
}
