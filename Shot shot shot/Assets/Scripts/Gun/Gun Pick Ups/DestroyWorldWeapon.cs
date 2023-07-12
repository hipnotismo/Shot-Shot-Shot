using UnityEngine;

/// <summary>
/// Controls the destruction of world weapons
/// </summary>
public class DestroyWorldWeapon : MonoBehaviour
{
    [SerializeField] string CanCollideTag;

    /// <summary>
    /// Subscribes to the delegate on collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideTag)
        {
            PickUpWeapon.DestroyWeapon += DestroyWeapon;
        }
    }

    /// <summary>
    /// Unsubscribes to the delegate on collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideTag)
        {
            PickUpWeapon.DestroyWeapon -= DestroyWeapon;
        }
    }

    /// <summary>
    /// Unsubscribes to the delegate on collision when the object is disable
    /// </summary>
    private void OnDisable()
    {
        PickUpWeapon.DestroyWeapon -= DestroyWeapon;

    }

    /// <summary>
    /// Destroy game object
    /// </summary>
    private void DestroyWeapon()
    {
        Destroy(gameObject);
    }

}
