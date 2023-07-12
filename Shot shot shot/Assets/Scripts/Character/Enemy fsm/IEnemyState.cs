/// <summary>
/// Interface related to enemy states
/// </summary>
public interface IEnemyState
{
    /// <summary>
    /// Empty method for behaviors in each state
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    IEnemyState Behavior(MovingEnemyStateMachine enemy);
}
