using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleState : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        //TODO: Fix - Bad log/Log out of context
        Debug.Log("We are in iddle state");
        return this;
    }
}
