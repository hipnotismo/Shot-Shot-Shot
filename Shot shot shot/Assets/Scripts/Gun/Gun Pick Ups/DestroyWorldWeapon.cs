using UnityEngine;

public class DestroyWorldWeapon : MonoBehaviour
{
    [SerializeField] string CanCollideTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideTag)
        {
            PickUpWeapon.DestroyWeapon += DestroyWeapon;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideTag)
        {
            PickUpWeapon.DestroyWeapon -= DestroyWeapon;
        }
    }

    private void OnDisable()
    {
        PickUpWeapon.DestroyWeapon -= DestroyWeapon;

    }

    private void DestroyWeapon()
    {
        Destroy(gameObject);
    }

}
