using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player/PlayerScriptableObject", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    public float MouseSensitivity;
    [SerializeField]
    public float MovementSpeed;
    [SerializeField]
    public float Life;

}
