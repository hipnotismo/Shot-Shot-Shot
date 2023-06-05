using UnityEngine;

public class DamageBoss : MonoBehaviour, ITakeDamage
{
    [SerializeField] BossHealth boss;
    [SerializeField] string collisionTag;
    public void TakeDamage()
    {
        Debug.Log("boss takes damage");
        boss.LossBossHealth();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == collisionTag)
        {
            TakeDamage();
        }

    }
}
