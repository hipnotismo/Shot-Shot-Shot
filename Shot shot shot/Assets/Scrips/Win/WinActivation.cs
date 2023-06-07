using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinActivation : MonoBehaviour
{
    //TODO: TP2 - Syntax - Consistency in naming convention
    [SerializeField] GameObject win;
    //TODO: TP2 - Remove unused methods/variables
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: Fix - Bad log/Log out of context
        Debug.Log(other);

        Debug.Log(other.tag);

        //TODO: Fix - Hardcoded value
        if (other.tag == "Player")
        {
            //TODO: Fix - Bad log/Log out of context
            Debug.Log("Player is wining");
            //TODO: TP2 - SOLID
            Time.timeScale = 0;
            win.SetActive(true);
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);

        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is wining");
            Time.timeScale = 0;
            win.SetActive(true);
        }
    }
}
