using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] int life;
    private bool inmune = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colides");

        if (other.tag == "Enemy")
        {
            Debug.Log("Colides with enemy");

        }
    }

    public void TakeDamage() 
    {
        if (inmune==false)
        {
            life--;
            StartCoroutine(inmunity());
        }
       
    }

    IEnumerator inmunity() 
    {
        Debug.Log("we enter");
        inmune = true;
        yield return new WaitForSeconds(3);
        inmune = false;
        Debug.Log("we leave");
    }
}
