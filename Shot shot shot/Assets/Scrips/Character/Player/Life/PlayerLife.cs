using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] float life;
    [SerializeField] Image lifebar;
    [SerializeField] GameObject GameOverFace;

    private float MaxLifeReference;
    private bool inmune = false;
    // Start is called before the first frame update
    void Start()
    {
        MaxLifeReference = life;
       
    }

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    // Update is called once per frame
    void Update()
    {

        lifebar.fillAmount = life/ MaxLifeReference;
        if (life == 0)
        {
            GamerOver();
        }
    }

    //TODO: TP2 - SOLID
    private void GamerOver()
    {
        Time.timeScale = 0;
        GameOverFace.SetActive(true);

    }

    //TODO: TP2 - Remove unused methods/variables
    private void OnTriggerEnter(Collider other)
    {
      
    }

    public void TakeDamage() 
    {
        //TODO: TP2 - FSM
        if (inmune==false)
        {
            life--;
            StartCoroutine(inmunity());
        }
       
    }

    IEnumerator inmunity() 
    {
        //TODO: Fix - Bad log/Log out of context
        Debug.Log("we enter");
        inmune = true;
        yield return new WaitForSeconds(3);
        inmune = false;
        //TODO: Fix - Bad log/Log out of context
        Debug.Log("we leave");
    }
}
