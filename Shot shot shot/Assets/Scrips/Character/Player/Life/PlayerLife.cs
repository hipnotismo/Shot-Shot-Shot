using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] float life;
    [SerializeField] Image lifebar;
    [SerializeField] GameObject GameOverFace;

    private float MaxLifeReference;
    private bool inmune = false;
    private void Start()
    {
        MaxLifeReference = life;
       
    }

    private void Update()
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
        inmune = true;
        yield return new WaitForSeconds(3);
        inmune = false;
    }
}
