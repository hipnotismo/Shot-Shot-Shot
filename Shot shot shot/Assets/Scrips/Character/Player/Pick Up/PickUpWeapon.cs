using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public delegate void EquipAction(int ID);
    public static event EquipAction EquipWeapon;

    public delegate void DropAction(int ID);
    public static event DropAction DropWeapon;

    public delegate void DestroyAction();
    public static event DestroyAction DestroyWeapon;

    [SerializeField] private EventMangerScriptable Manager;
    [SerializeField] private Transform WeaponPoint;
    [SerializeField] private List<string> TagToReceive = new List<string>();
    [SerializeField] private int ID = 0;
    [SerializeField] private int TempID = 0;
    [SerializeField] private bool IsColliding = false;

    private void OnEnable()
    {
        InputManager.PickUp += Equip;
        InputManager.Drop += Drop;
        Manager.StartListening(TagToReceive[0], SetID);
        Manager.StartListening(TagToReceive[1], CleanID);

    }

    private void OnDisable()
    {
        InputManager.PickUp -= Equip;
        InputManager.Drop -= Drop;
        Manager.StopListening(TagToReceive[0], SetID);
        Manager.StartListening(TagToReceive[1], CleanID);


    }

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    private void Drop()
    {
        DropWeapon(ID);
        //if (gun != null)
        //{
        //    WeaponPoint.DetachChildren();
        //    gun.transform.eulerAngles = new Vector3(gun.transform.position.x, gun.transform.position.z, gun.transform.position.y);
        //    gun.GetComponent<Rigidbody>().isKinematic = false;
        //    gun.GetComponent<MeshCollider>().enabled = true;
        //    gun = null;
        //}

    }

    /// <summary>
    /// Sends the ID to the GunManager
    /// </summary>
    public void Equip()
    {
        if (IsColliding == true)
        {
            ID = TempID;
            EquipWeapon(ID);
            DestroyWeapon();
        }
        //if (gun == null && gun2 != null)
        //{

        //    gun = gun2;
        //    gun.GetComponent<Rigidbody>().isKinematic = true;

        //    gun.transform.position = WeaponPoint.transform.position;
        //    gun.transform.rotation = WeaponPoint.transform.rotation;

        //    gun.GetComponent<MeshCollider>().enabled = false;
        //    gun.transform.SetParent(WeaponPoint);
        //    int WeaponLayer = LayerMask.NameToLayer("weapon");

        //    gun.gameObject.layer = WeaponLayer;

        //    foreach (Transform child in gun.transform)
        //    {
        //        child.gameObject.layer = WeaponLayer;
        //    }
        //}

    }

    private void SetID(Dictionary<string, object> message)
    {
        TempID = (int)message["ID"];
        IsColliding = true;
    }

    private void CleanID(Dictionary<string, object> message)
    {
        TempID = 0;
        IsColliding = false;
    }
}
