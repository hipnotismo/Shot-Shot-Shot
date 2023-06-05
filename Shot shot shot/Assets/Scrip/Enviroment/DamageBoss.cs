using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour, ITakeDamage
{
    [SerializeField] BossHealth boss;

    //TODO: TP2 - Remove unused methods/variables
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
       

        //TODO: Fix - Hardcoded value
        if (other.tag == "bullet")
        {
            TakeDamage();
        }

    }
}
