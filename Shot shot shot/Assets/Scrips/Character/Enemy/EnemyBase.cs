using UnityEngine;
/// <summary>
/// Basic fields present in all enemies
/// </summary>
public class EnemyBase : MonoBehaviour, ITakeDamage
{

    [SerializeField] string CanTakeDamageFromTag;
    [SerializeField] string CanDamageTag;

    public void TakeDamage()
    {
        Destroy(gameObject);       
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == CanTakeDamageFromTag)
        {
            TakeDamage();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == CanDamageTag)
        {           
            ITakeDamage isHit = collision.gameObject.GetComponent<ITakeDamage>();
            if (isHit != null)
            {
                isHit.TakeDamage();
            }
        }

        if (collision.gameObject.tag == CanTakeDamageFromTag)
        {

            TakeDamage();
        }
    }
}
