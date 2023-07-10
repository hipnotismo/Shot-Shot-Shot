using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, ITakeDamage
{
    public delegate void GameOverAction();
    public static event GameOverAction GameOver;

    [SerializeField] PlayerData PlayerData;
    [SerializeField] Image lifebar;

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
            GameOver();
        }
    }
   

    public void TakeDamage() 
    {
        if (immune==false)
        {
            TempLife--;
            StartCoroutine(immunity());
        }
    }

    IEnumerator immunity() 
    {
        immune = true;
        yield return new WaitForSeconds(3);
        immune = false;
    }
}
