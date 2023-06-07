using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    //TODO: Documentation - Add summary
    IEnemyState Behavior(MovingEnemyStateMachine enemy);
}
