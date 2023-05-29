using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinActivation : MonoBehaviour
{
    [SerializeField] GameObject win;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            Debug.Log("Player is wining");
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
