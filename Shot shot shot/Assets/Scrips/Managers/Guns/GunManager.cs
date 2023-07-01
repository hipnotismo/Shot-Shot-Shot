using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] WeaponList WeaponList;
    [SerializeField] Transform WeaponPoint;

    private void OnEnable()
    {
        PickUpWeapon.EquipWeapon += CreateWeapon;
        PickUpWeapon.DropWeapon += DestroyWeapon;
    }

    private void OnDisable()
    {
        PickUpWeapon.EquipWeapon -= CreateWeapon;
        PickUpWeapon.DropWeapon -= DestroyWeapon;

    }

    private void CreateWeapon(int ID)
    {
        Instantiate(WeaponList.WeaponPrefabs[ID],WeaponPoint);
    }

    private void DestroyWeapon(int ID)
    {
        Destroy(WeaponPoint.GetChild(0).gameObject);
        Instantiate(WeaponList.WorldWeaponPrefabs[ID], WeaponPoint.position, Quaternion.identity);

    }
}
