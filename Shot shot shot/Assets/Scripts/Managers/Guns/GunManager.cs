using UnityEngine;

/// <summary>
/// Takes a list with weapon prefabs and an ID to insatiate a weapon as the child of a game object 
/// </summary>
public class GunManager : MonoBehaviour
{
    [SerializeField] WeaponList WeaponList;
    [SerializeField] Transform WeaponPoint;

    /// <summary>
    /// Subscribes to events
    /// </summary>
    private void OnEnable()
    {
        PickUpWeapon.EquipWeapon += CreateWeapon;
        PickUpWeapon.DropWeapon += DestroyWeapon;
    }


    /// <summary>
    /// Unsubscribes to events
    /// </summary>
    private void OnDisable()
    {
        PickUpWeapon.EquipWeapon -= CreateWeapon;
        PickUpWeapon.DropWeapon -= DestroyWeapon;

    }

    /// <summary>
    /// Takes an ID and instantiates a prefab that is store in the WeaponPrefabs list
    /// </summary>
    /// <param name="ID"></param>
    private void CreateWeapon(int ID)
    {
        Instantiate(WeaponList.WeaponPrefabs[ID],WeaponPoint);
    }

    /// <summary>
    /// Destroys all children from a game object and instantiates a weapon picable from the WorldWeaponPrefabs list
    /// </summary>
    /// <param name="ID"></param>
    private void DestroyWeapon(int ID)
    {
        Destroy(WeaponPoint.GetChild(0).gameObject);
        Instantiate(WeaponList.WorldWeaponPrefabs[ID], WeaponPoint.position, Quaternion.identity);

    }
}
