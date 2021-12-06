using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private BattleController battleController;

    public Player PlayerOwner;
    public float Power;

    public  ObjectLifeCycle LifeCycle = new ObjectLifeCycle();

    //TODO remove hardcode value
    float timeBetweenNodes = 0.2f;

    public void Initialize(Player owner, float initialPower, Vector3 position, BattleController battleController)
    {
        this.battleController = battleController;
        PlayerOwner = owner;
        Power = initialPower;
        this.transform.position = position;

        ChangeColor();

        LifeCycle.Initializated();
    }

    private void ChangeColor()
    {
        if (PlayerOwner)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", PlayerOwner.EnemyColor);
        }

    }

    public Player GetPlayer()
    {
        return PlayerOwner;
    }

    public void GetConquered(Player newOwner)
    {
        PlayerOwner = newOwner;
        if(Power < 0)
        {
            Power *= -1;
        }
        ChangeColor();

        EventBus.Instance.TriggerEvent(EventName.NodeConquered, new ParameterBusObject(this));


    }

    public void IncreaseValue()
    {
        if (PlayerOwner)
        {
            Power += PlayerOwner.GetUnitGrowPerSecond() * Time.deltaTime;
        }
    }

    public void ReceiveHit(Unit unit)
    {
        if(PlayerOwner == unit.GetPlayerOwner())
        {
            Power += unit.GetPower();
        }
        else
        {
            Power -= unit.GetPower();
            if (Power < 0)
            {
                GetConquered(unit.GetPlayerOwner());
            }
        }
    }

    public void Attack(Node enemyNode)
    {
        int unitsToAttack = (int) (Power * 0.5f);
        Power -= unitsToAttack;
        for (int i = 0; i < unitsToAttack; i++)
        {
            Unit unit =(Unit) battleController.unitPool.GetFreeObject();
            unit.StartMoving(this, 1, enemyNode, timeBetweenNodes*i);
        }
    }

    public void OnMouseDown()
    {
        EventBus.Instance.TriggerEvent(EventName.NodeTapped,new ParameterBusObject(this));
    }
}
