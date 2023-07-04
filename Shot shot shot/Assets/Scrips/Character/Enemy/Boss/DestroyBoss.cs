using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{
    [SerializeField] private EventMangerScriptable Manager;
    [SerializeField] string TagToSend;
    [SerializeField] string MessageToSend;

    private void OnDestroy()
    {
        Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });

    }
}
