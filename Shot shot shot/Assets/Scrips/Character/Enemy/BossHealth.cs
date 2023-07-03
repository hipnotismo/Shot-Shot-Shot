using UnityEngine;
/// <summary>
/// Class to control the boss health
/// </summary>
public class BossHealth : MonoBehaviour
{
    [SerializeField] private int bossTotalHealth;
    //TODO: TP2 - SOLID
    [SerializeField] GameObject win;

    /// <summary>
    /// Normally call from another class or method to reduce the bossTotalHealt and check if it less than zero to destroy the object and activate the win screen.
    /// </summary>
    public void LossBossHealth()
    {
        bossTotalHealth--;
        if (bossTotalHealth < 1)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            win.SetActive(true);
        }
    }
}
