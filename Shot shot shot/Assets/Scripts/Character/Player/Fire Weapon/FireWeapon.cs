using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public delegate void ShootAction();
    public static event ShootAction ShootWeapon;

    private bool IsWeaponEquip = false;

    private void OnEnable()
    {
        InputManager.ShootFromPickUp += Shoot;
        PickUpWeapon.CanFireWeapon += DetectEquip;
    }

    private void OnDisable()
    {
        InputManager.ShootFromPickUp -= Shoot;
        PickUpWeapon.CanFireWeapon -= DetectEquip;

    }

    private void Shoot()
    {

        if (IsWeaponEquip)
        {
            ShootWeapon();
        }
    }

    private void DetectEquip()
    {
        IsWeaponEquip = !IsWeaponEquip;
    }
}
