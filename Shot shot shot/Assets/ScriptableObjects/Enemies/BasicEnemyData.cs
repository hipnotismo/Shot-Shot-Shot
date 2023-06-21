using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicEnemyData", menuName = "ScriptableObjects/BasicEnemyDataScriptableObject", order = 1)]

public class BasicEnemyData : ScriptableObject
{
    [SerializeField] public GameObject ModelPrefab;

}
