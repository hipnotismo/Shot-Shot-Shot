using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunTrailData", menuName = "ScriptableObjects/GunProjectileScriptableObject", order = 3)]

public class GunProjectileData : GunTrailData
{
    [SerializeField]
    public GameObject Bullet;
}
