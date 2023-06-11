using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    void Start()
    {
        EventManager.TriggerEvent("addCoins", new Dictionary<string, object> { { "amount", 1 } });
    }
}
