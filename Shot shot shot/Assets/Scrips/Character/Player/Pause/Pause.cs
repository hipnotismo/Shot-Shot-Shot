using UnityEngine;

public class Pause : MonoBehaviour
{
    public delegate void ActivationAction();
    public static event ActivationAction Activation;

    public delegate void DeActivationAction();
    public static event DeActivationAction DeActivation;

    private void OnValidate()
    {
        InputManager.Pause += EnterPause;
        InputManager.Resume += ExitPause;

    }

    private void OnDisable()
    {
        InputManager.Pause -= EnterPause;
        InputManager.Resume -= ExitPause;
    }
 
    public void EnterPause()
    {
        Time.timeScale = 0;
        Activation();
    }
    public void ExitPause()
    {
        Time.timeScale = 1;
        DeActivation();
    }
}
