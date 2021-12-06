using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    private float secondsBetweenDecision = float.MaxValue;
    private float timeLeftToDecision = 0;
    private float randomFactorOnDecision = 1f;


    public override void Initialize(PlayerScriptableObject so, BattleController battleController)
    {
        this.battleController = battleController;
        Name = so.Name;
        EnemyColor = so.EnemyColor;
        unitGrowPerSecond = so.UnitIncreasePerSecond;
        randomFactorOnDecision = so.RandomFactorDecision;
        secondsBetweenDecision = so.TimeToTakeDecision;

        timeLeftToDecision = secondsBetweenDecision * Random.Range(randomFactorOnDecision,1+ randomFactorOnDecision);
            
    }
    public void TakeDecision()
    {
        timeLeftToDecision -= Time.deltaTime;
        if (timeLeftToDecision < 0)
        {
            Debug.Log("Player " + Name + " is making his move");
            timeLeftToDecision = secondsBetweenDecision * Random.Range(randomFactorOnDecision, 1 + randomFactorOnDecision);

            Node node = battleController.GetWeakestRivalNode(this);
            if(node != null)
            {
                battleController.Attack(node, this);
            }
        }
    }

}
