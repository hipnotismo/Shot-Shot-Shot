using UnityEngine;

/// <summary>
/// Class that destroys current game object
/// </summary>
public class DestroyObject : MonoBehaviour
{
    /// <summary>
    /// Method that destroys current game object
    /// </summary>
    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
