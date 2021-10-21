using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Player PlayerOwner;
    public float Power;


    public  ObjectLifeCycle LifeCycle = new ObjectLifeCycle();

    public void Initialize(Player owner, float initialPower, Vector3 position)
    {
        PlayerOwner = owner;
        Power = initialPower;
        this.transform.position = position;

        if (owner)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", owner.EnemyColor);
        }

        LifeCycle.Initializated();
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
        if (PlayerOwner)
        {
            Power += PlayerOwner.GetUnitGrowPerSecond() * Time.deltaTime;
        }
    }


}
