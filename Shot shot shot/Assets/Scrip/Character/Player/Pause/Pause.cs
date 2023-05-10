using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void ActivationAction();
    public static event ActivationAction Activation;

    public delegate void DeActivationAction();
    public static event DeActivationAction DeActivation;

    private void OnValidate()
    {
        InputManager.Pause += EnterPause;
        InputManager.Resume += ExitPause;

    }

    private void OnDisable()
    {
        InputManager.Pause -= EnterPause;
        InputManager.Resume -= ExitPause;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterPause()
    {
        Time.timeScale = 0;
        Activation();
    }
    public void ExitPause()
    {
        Time.timeScale = 1;
        DeActivation();
    }
}
