using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Player", order = 1)]
public class PlayerScriptableObject : ScriptableObject
{
    public string Name;
    public Color EnemyColor;
    public float UnitIncreasePerSecond = 1;
    public float TimeToTakeDecision = 6;
    
    [Range(0.001f,1f)]
    public float RandomFactorDecision = 1f;
}
