using System.Collections;
using UnityEngine;

/// <summary>
/// Class that takes damage for the player
/// </summary>
public class PlayerLife : MonoBehaviour, ITakeDamage
{
    public delegate void GameOverAction();
    public static event GameOverAction GameOver;

    public delegate void LifeUIAction(float LifeFill);
    public static event LifeUIAction LifeBarUI;

    [SerializeField] private PlayerData PlayerData;

    private float TempLife;
    private bool immune = false;

    /// <summary>
    /// Sets TempLife as the player max life 
    /// </summary>
    private void Start()
    {
        TempLife = PlayerData.Life;
    }

    /// <summary>
    /// Updates the LifeBarUI with the current life divided by the max life and checks if the player has lost
    /// </summary>
    private void Update()
    {
        LifeBarUI(TempLife / PlayerData.Life);

        if (TempLife == 0)
        {
            GameOver();
        }
    }
   
    /// <summary>
    /// When the damage interface is activated it lowers the temporary life and activates the immunity coroutine
    /// </summary>
    public void TakeDamage() 
    {
        if (immune==false)
        {
            TempLife--;
            StartCoroutine(immunity());
        }
    }

    /// <summary>
    /// Activates and deactivates the Inmune bool for three seconds and stops the player from taking damage
    /// </summary>
    /// <returns></returns>
    IEnumerator immunity() 
    {
        immune = true;
        yield return new WaitForSeconds(3);
        immune = false;
    }
}
