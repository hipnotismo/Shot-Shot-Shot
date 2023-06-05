using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO - Documentation - Add summary
public class BossHealth : MonoBehaviour
{
    private int healt = 3;
    //TODO: TP2 - SOLID
    [SerializeField] GameObject win;

    //TODO: TP2 - Remove unused methods/variables
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //TODO: TP2 - Syntax - Consistency in naming convention (is LoseHealth)
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
