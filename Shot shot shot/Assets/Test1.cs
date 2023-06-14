using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [SerializeField] GunData gun;
    void Start()
    {
        EventManager.TriggerEvent("addCoins", new Dictionary<string, object> { { "amount", gun } });
    }
}
