using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private int coins;
    private GunData gunData;
    void OnEnable()
    {
        EventManager.StartListening("addCoins", OnAddCoins);
    }

    void OnDisable()
    {
        EventManager.StopListening("addCoins", OnAddCoins);
    }

    void OnAddCoins(Dictionary<string, object> message)
    {
        //var amount = (int)message["amount"];
        //coins += amount;
        gunData = (GunData)message["amount"];
        if (gunData != null)
        {
            Debug.Log("Yes data");

        }
        else
        {
            Debug.Log("No data");

        }
    }
}
