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

    private void Drop()
    {
        DropWeapon(ID);
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
