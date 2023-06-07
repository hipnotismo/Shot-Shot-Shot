/// <summary>
/// Interface to implement damage related code
/// example:
/// Enemy class triggers on enter Other.TakeDamage
/// That can activate the TakeDage field from any class that has it like Player, Obstacle, etc.
/// </summary>
public interface ITakeDamage
{
    public void TakeDamage();
}
