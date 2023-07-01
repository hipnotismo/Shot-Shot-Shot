using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/GunScriptableObject", order = 1)]

public class GunData : ScriptableObject
{
    [SerializeField] public GameObject ModelPrefab;
    [SerializeField] public int Id;
}
