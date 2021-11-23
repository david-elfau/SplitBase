using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BattleController battleController;
    public string Name;
    public Color EnemyColor;
    protected float unitGrowPerSecond;

    public virtual void Initialize(PlayerScriptableObject so, BattleController battleController)
    {
        this.battleController = battleController;
        Name = so.Name;
        EnemyColor = so.EnemyColor;
        unitGrowPerSecond = so.UnitIncreasePerSecond;
    }

    public float GetUnitGrowPerSecond()
    {
        return unitGrowPerSecond;
    }
}
