using UnityEngine;

[CreateAssetMenu(fileName = "EnemysType", menuName = "Enemys/EnemysData")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private string enemeyType;

    public string EnemyType {get => enemeyType; set => enemeyType = value; }

}
