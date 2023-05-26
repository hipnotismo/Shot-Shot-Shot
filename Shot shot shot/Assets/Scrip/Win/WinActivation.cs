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
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            win.SetActive(true);
        }
      
    }
}
