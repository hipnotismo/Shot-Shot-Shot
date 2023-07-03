using UnityEngine;

public class BuletDamage : MonoBehaviour/*, ITakeDamage*/
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet git " + other.name);
        ITakeDamage isHit = other.GetComponent<ITakeDamage>();
        //isHit.TakeDamage();

    }

    ////TODO: TP2 - SOLID
    //public void TakeDamage()
    //{
    //}
}
