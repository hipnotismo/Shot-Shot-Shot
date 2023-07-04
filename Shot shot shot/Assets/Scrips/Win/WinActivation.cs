using UnityEngine;
using System.Collections.Generic;

public class WinActivation : MonoBehaviour
{
    public delegate void WinAction();
    public static event WinAction WinGame;

    [SerializeField] private EventMangerScriptable Manager;
    [SerializeField] string TagToSend;
    [SerializeField] string MessageToSend;
    [SerializeField] private string CanCollideWithTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CanCollideWithTag)
        {
            Time.timeScale = 0;
            Manager.TriggerEvent(TagToSend, new Dictionary<string, object> { { MessageToSend, null } });
        }
    }
}
