using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponList/WeaponList")]
public class WeaponList : ScriptableObject
{
    [SerializeField] public List<GameObject> WeaponPrefabs = new List<GameObject>();
    [SerializeField] public List<GameObject> WorldWeaponPrefabs = new List<GameObject>();


}
