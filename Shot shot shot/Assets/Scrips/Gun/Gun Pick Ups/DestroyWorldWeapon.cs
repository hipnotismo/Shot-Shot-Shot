using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWorldWeapon : MonoBehaviour
{
    private void OnEnable()
    {
        PickUpWeapon.DestroyWeapon += DestroyWeapon;
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
