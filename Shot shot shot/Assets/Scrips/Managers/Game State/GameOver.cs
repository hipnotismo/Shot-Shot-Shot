using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverFace;

    private void OnEnable()
    {
        Time.timeScale = 1f; //the game need this to be somewhere to re start correctly and it fits here
        PlayerLife.GameOver += GamerOver;
    }

    private void OnDisable()
    {
        PlayerLife.GameOver -= GamerOver;
    }
  
    private void GamerOver()
    {
        Time.timeScale = 0;
        GameOverFace.SetActive(true);

    }
}
