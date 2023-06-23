using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testt : MonoBehaviour
{
    [SerializeField] GunData testttt;
    [SerializeField] CoinCounter coin;
    void Start()
    {
        GameObject visuals = Instantiate(testttt.ModelPrefab);
        visuals.transform.parent = this.transform;
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
