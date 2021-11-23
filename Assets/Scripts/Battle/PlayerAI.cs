using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    private float secondsBetweenDecision = 6;
    private float timeLeftToDecision = 0;


    public override void Initialize(PlayerScriptableObject so, BattleController battleController)
    {
        this.battleController = battleController;
        Name = so.Name;
        EnemyColor = so.EnemyColor;
        unitGrowPerSecond = so.UnitIncreasePerSecond;
        timeLeftToDecision = secondsBetweenDecision;
            
    }
    public void TakeDecision()
    {
        timeLeftToDecision -= Time.deltaTime;
        if (timeLeftToDecision < 0)
        {
            //TODO
            Debug.Log("Player " + Name + " is making his move");
            timeLeftToDecision = secondsBetweenDecision;
            Node node = battleController.GetWeakestRivalNode(this);
            if(node != null)
            {
                battleController.Attack(node, this);
            }
        }
    }

}
