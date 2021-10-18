using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleProgressionManager : GenericManager
{
    public List<BattleScriptableObject> BattleList;
    private int currentBattle;

    public override void Initialize()
    {
        currentBattle = 0;
        initializated = true;
    }

    public void LoadNextBattle()
    {
        currentBattle++;
        LoadBattle();
    }

    public void LoadBattle()
    {
        LoadBattle(BattleList[currentBattle]); 
    }

    private void LoadBattle(BattleScriptableObject battle)
    {
        if (battle)
        {
            //TODO Call to the battle generator
        }
        else
        {
            Debug.LogError("Battle Manager: No battle found");
        }
    }

    public BattleScriptableObject GetBattleScriptableObject()
    {
        return BattleList[currentBattle];
    }
}
