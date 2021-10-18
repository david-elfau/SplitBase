using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Player", order = 1)]
public class PlayerScriptableObject : ScriptableObject
{
    public string Name;
    public Color EnemyColor;
    public float UnitIncreasePerSecond = 1;
}
