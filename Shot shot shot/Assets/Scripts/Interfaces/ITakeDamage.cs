/// <summary>
/// Interface to implement damage related code
/// example:
/// Enemy class triggers on enter Other.TakeDamage
/// That can activate the TakeDamage field from any class that has it like Player, Obstacle, etc.
/// </summary>
public interface ITakeDamage
{
    /// <summary>
    /// Empty interface 
    /// </summary>
    public void TakeDamage();
}
