using UnityEngine;

/// <summary>
/// Makes sure that the game is running at time scale 1 at the beginning
/// </summary>
public class EmergencyCheck : MonoBehaviour
{
    /// <summary>
    /// Sets time scale to 1
    /// </summary>
    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }
}
