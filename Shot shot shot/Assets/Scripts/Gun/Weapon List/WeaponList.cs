using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that contains two list
/// WeaponPrefabs: contains hte prefabs for the weapons that the player can use
/// WorldWeaponPrefabs: weapons that appear in teh map and the player can interact with 
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObjects/WeaponList/WeaponList")]
public class WeaponList : ScriptableObject
{
    [SerializeField] public List<GameObject> WeaponPrefabs = new List<GameObject>();
    [SerializeField] public List<GameObject> WorldWeaponPrefabs = new List<GameObject>();


}
