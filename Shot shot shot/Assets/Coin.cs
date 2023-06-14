using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] EventMangerScriptable manager;
    [SerializeField] string tag;
    [SerializeField] GunBase Gun;
    void Start()
    {
        //Gun = new GunBaseRay();

        Debug.Log(this.name + " is starting");
        manager.TriggerEvent(tag, new Dictionary<string, object> { { "amount", Gun } });
    }
}
