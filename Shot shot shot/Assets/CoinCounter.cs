using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] EventMangerScriptable manager;
    [SerializeField] string tag;
    private int coins;
    GunBase Guns;

    void OnEnable()
    {
        manager.StartListening(tag, OnAddCoins);
    }

    void OnDisable()
    {
        manager.StopListening(tag, OnAddCoins);
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
       //     Debug.Log(this.name + " Guns is not null");

       // }
    }
}
