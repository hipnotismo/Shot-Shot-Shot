using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private int coins;

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
        var amount = (int)message["amount"];
        coins += amount;
    }
}
