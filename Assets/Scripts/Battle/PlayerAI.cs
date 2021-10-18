using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    private float secondsBetweenDecision = 3;
    private float timeLeftToDecision = 0;


    public override void Initialize(PlayerScriptableObject so)
    {
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
        }
    }

}
