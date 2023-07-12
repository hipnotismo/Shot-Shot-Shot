using UnityEngine;

/// <summary>
/// Class that activates the interface dedicated to damage
/// </summary>
public class BulletDamage : MonoBehaviour
{
    /// <summary>
    /// Mothod that activates teh damage interface when the game object collides with another
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit " + nameof(other.name));
        ITakeDamage isHit = other.GetComponent<ITakeDamage>();
    }
}
