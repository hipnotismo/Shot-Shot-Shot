using UnityEngine;

/// <summary>
/// Class that manages the firing of weapons
/// </summary>
public class FireWeapon : MonoBehaviour
{
    public delegate void ShootAction();
    public static event ShootAction ShootWeapon;

    private bool IsWeaponEquip = false;

    /// <summary>
    /// Subscribes to input manager and pick up weapon
    /// </summary>
    private void OnEnable()
    {
        InputManager.ShootFromPickUp += Shoot;
        PickUpWeapon.CanFireWeapon += DetectEquip;
    }

    /// <summary>
    /// Unsubscribes to input manager and pick up weapon
    /// </summary>
    private void OnDisable()
    {
        InputManager.ShootFromPickUp -= Shoot;
        PickUpWeapon.CanFireWeapon -= DetectEquip;

    }

    /// <summary>
    /// If a weapon is equip activates the shoot method of that weapon
    /// </summary>
    private void Shoot()
    {

        if (IsWeaponEquip)
        {
            ShootWeapon();
        }
    }

    /// <summary>
    /// Switches the IsWeaponEquip bool
    /// </summary>
    private void DetectEquip()
    {
        IsWeaponEquip = !IsWeaponEquip;
    }
}
