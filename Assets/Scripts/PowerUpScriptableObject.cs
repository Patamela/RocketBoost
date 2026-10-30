using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUps/PowerUpData")]
public class PowerUpScriptableObject : ScriptableObject
{
    [SerializeField] private string powerUpType;
    [SerializeField] private float powerUpValue;

    public string PowerUpType {get => powerUpType; set => powerUpType = value; }
    public float PowerUpValue {get => powerUpValue; set => powerUpValue = value; }
}
