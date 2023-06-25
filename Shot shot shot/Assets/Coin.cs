using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] EventMangerScriptable Manager;
    [SerializeField] string Tag;
    [SerializeField] GunBase Gun;
    void Start()
    {
        //Gun = new GunBaseRay();

        Debug.Log(this.name + " is starting");
        Manager.TriggerEvent(Tag, new Dictionary<string, object> { { "amount", Gun } });
    }
}
