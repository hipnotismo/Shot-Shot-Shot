using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private int healt = 3;
    [SerializeField] GameObject win;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LossLife()
    {
        healt--;
        if (healt < 1)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            win.SetActive(true);
        }
    }
}
