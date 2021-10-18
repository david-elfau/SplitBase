using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Player PlayerOwner;
    private float Power;


    private ObjectLifeCycle lifeCycle = new ObjectLifeCycle();

    public void Initialize(Player owner, float initialPower, Vector3 position)
    {
        PlayerOwner = owner;
        Power = initialPower;
        this.transform.position = position;

        if (owner)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", owner.EnemyColor);
        }



        lifeCycle.Initializated();
    }

    public Player GetPlayer()
    {
        return PlayerOwner;
    }

    public void GetConquered(Player newOwner)
    {
        PlayerOwner = newOwner;
    }

    public void IncreaseValue()
    {
        Power += PlayerOwner.GetUnitGrowPerSecond() * Time.deltaTime;
    }


}
