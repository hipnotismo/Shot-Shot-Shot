using UnityEngine;

public class BuletDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit " + other.name);
        ITakeDamage isHit = other.GetComponent<ITakeDamage>();
    }
}
