using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] EventMangerScriptable Manager;
    [SerializeField] string Tag;
    private int coins;
    GunBase Guns;

    void OnEnable()
    {
        Manager.StartListening(Tag, OnAddCoins);
    }

    void OnDisable()
    {
        Manager.StopListening(Tag, OnAddCoins);
    }

    void OnAddCoins(Dictionary<string, object> message)
    {
       ////var amount = (int)message["amount"];
       // //coins += amount;

       // Guns = (GunBase)message["amount"];

       // if (Guns == null)
       // {
       //     Debug.Log(this.name + " Guns is null");
       // }
       // else
       // {
            Debug.Log(this.name + " Guns is not null");

       // }
    }
}
