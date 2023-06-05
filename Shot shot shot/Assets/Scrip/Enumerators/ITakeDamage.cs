/// <summary>
/// Interface to implement damage related code
/// example:
/// Enemy class triggers on enter Other.TakeDmage
/// That can activate the TakeDage field from any class that has it like Player, Obstacle, etc.
/// </summary>
public interface ITakeDamage//ITakeDamage
{
    public void TakeDamage();
}
