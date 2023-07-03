using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] PlayerData PlayerData;
    [SerializeField] Image lifebar;
    [SerializeField] GameObject GameOverFace;

    private float TempLife;
    private bool immune = false;

    private void Start()
    {
        TempLife = PlayerData.Life;
       
    }

    private void Update()
    {

        lifebar.fillAmount =  TempLife / PlayerData.Life;

        if (TempLife == 0)
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
        Debug.Log(this.name + " is taking damage");
        if (immune==false)
        {
            TempLife--;
            StartCoroutine(immunity());
        }
        Debug.Log(this.name + " current life = " + TempLife);
    }

    IEnumerator immunity() 
    {
        immune = true;
        yield return new WaitForSeconds(3);
        immune = false;
    }
}
