using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testt : MonoBehaviour
{
    [SerializeField] GunData testttt;
    [SerializeField] CoinCounter coin;
    [SerializeField] GameObject gun;

    void Start()
    {
        GameObject visuals =
        Instantiate(gun, this.transform.position, Quaternion.identity);
        visuals.transform.parent = this.transform;
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject + " is colliding");

    }
}
