using UnityEngine;

public class WinActivation : MonoBehaviour
{
    public delegate void WinAction();
    public static event WinAction WinGame;

    [SerializeField] private string CanCollideWithTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideWithTag)
        {
            Time.timeScale = 0;
            WinGame();
        }
    }
}
