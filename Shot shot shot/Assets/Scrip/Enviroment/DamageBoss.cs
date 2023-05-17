using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour, ITakeDamage
{
    [SerializeField] BossHealth boss;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage()
    {
        Debug.Log("boss takes damage");
        boss.LossLife();
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.tag == "bullet")
        {
            TakeDamage();
        }

    }
}
