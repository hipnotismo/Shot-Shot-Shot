using UnityEngine;

/// <summary>
/// Class that controls the pause function
/// </summary>
public class Pause : MonoBehaviour
{
    public delegate void ActivationAction();
    public static event ActivationAction Activation;

    public delegate void DeActivationAction();
    public static event DeActivationAction DeActivation;

    /// <summary>
    /// Subscribes to the input manager
    /// </summary>
    private void OnEnable()
    {
        InputManager.Pause += EnterPause;
        InputManager.Resume += ExitPause;

    }

    /// <summary>
    /// Unsubscribes to the input manager
    /// </summary>
    private void OnDisable()
    {
        InputManager.Pause -= EnterPause;
        InputManager.Resume -= ExitPause;
    }
 
    /// <summary>
    /// Sets time scale to 0
    /// </summary>
    public void EnterPause()
    {
        Time.timeScale = 0;
        Activation();
    }

    /// <summary>
    /// Sets time scale to 1
    /// </summary>
    public void ExitPause()
    {
        Time.timeScale = 1;
        DeActivation();
    }
}
