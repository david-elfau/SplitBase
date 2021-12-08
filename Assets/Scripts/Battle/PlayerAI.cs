using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    private float secondsBetweenDecision = float.MaxValue;
    private float timeLeftToDecision = 0;
    private float randomFactorOnDecision = 1f;

    private Node lastNodeAttacked = null;

    public struct WeightedNode
    {
        public Node node;
        public float weight;
    }


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

            Node nodeToAttack = GetDestinyNode();
            lastNodeAttacked = nodeToAttack;
            if (nodeToAttack != null)
            {
                battleController.Attack(nodeToAttack, this);
            }
        }
    }

    private Node GetDestinyNode()
    {

        List <WeightedNode> candidateNodes = new List<WeightedNode>();

        float acumulatedWeight =0;
        foreach (Node node in battleController.nodeList)
        {
            if (node.PlayerOwner != this)
            {
                float weight = 1f / (node.Power* node.Power);
                if(node == lastNodeAttacked)
                {
                    //Boost repeat last node attacked
                    weight *= 2f;
                }

                acumulatedWeight += weight;
                WeightedNode weightedNode = new WeightedNode();

                weightedNode.weight = weight;
                weightedNode.node = node;

                candidateNodes.Add(weightedNode);

            }
        }

        float weightSelected = Random.Range(0, acumulatedWeight);

        acumulatedWeight = 0;
        foreach (WeightedNode weightedNode in candidateNodes)
        {
            if(weightSelected <= acumulatedWeight+ weightedNode.weight)
            {
                return weightedNode.node;
            }
            acumulatedWeight += weightedNode.weight;

        }
        return null;
    }

}
