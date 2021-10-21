using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleProgressionManager : GenericManager
{
    [SerializeField] private List<BattleScriptableObject> BattleList;

    public BattleScriptableObject GetBattle(int index)
    {
        return BattleList[index]; 
    }
}
