using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that conrols how filled the life bar should be
/// </summary>
public class LifeUI : MonoBehaviour
{
  
    [SerializeField] private Image lifebar;

    /// <summary>
    /// Subscribes to PlayerLife
    /// </summary>
    private void OnEnable()
    {
        PlayerLife.LifeBarUI += FillLifeBar;
    }

    /// <summary>
    /// Unsubscribes to PlayerLife
    /// </summary>
    private void OnDisable()
    {
        PlayerLife.LifeBarUI -= FillLifeBar;

    }

    /// <summary>
    /// Recibes a float and set the fill of the life bar to it
    /// </summary>
    /// <param name="LifeFill"></param>
    public void FillLifeBar(float LifeFill)
    {
        lifebar.fillAmount = LifeFill;
    }
}
