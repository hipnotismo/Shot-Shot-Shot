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

    public delegate void FireAction();
    public static event FireAction CanFireWeapon;

    [SerializeField] private EventManagerScriptable Manager;
    [SerializeField] private Transform WeaponPoint;
    [SerializeField] private List<string> TagToReceive = new List<string>();
    [SerializeField] string MessageToReceive;
    [SerializeField] private int ID = 0;
    [SerializeField] private int TempID = 0;
    [SerializeField] private bool IsColliding = false;
    [SerializeField] private bool CanDrop = false;
    [SerializeField] private bool CanPick = true;

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
        if (CanDrop == true)
        {
            DropWeapon(ID);
            CanFireWeapon();
            CanDrop = false;
            CanPick = true;
        }
    }

    /// <summary>
    /// Sends the ID to the GunManager, destroys the wolrd weapon
    /// </summary>
    public void Equip()
    {
        if (IsColliding == true && CanPick == true)
        {
            ID = TempID;
            EquipWeapon(ID);
            DestroyWeapon();
            CanFireWeapon();
            CanDrop = true;
            CanPick = false;
        }
    }

    /// <summary>
    /// Takes the message that contains the ID of the weapon that could be equip after collision
    /// </summary>
    /// <param name="message"></param>
    private void SetID(Dictionary<string, object> message)
    {
        TempID = (int)message[MessageToReceive];
        IsColliding = true;
    }

    /// <summary>
    /// cleans the TempID field and detects that the collision has ended
    /// </summary>
    /// <param name="message"></param>
    private void CleanID(Dictionary<string, object> message)
    {
        TempID = 0;
        IsColliding = false;
    }
}
