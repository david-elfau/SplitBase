using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : PoolObject
{
    private Player playerOwner;
    private int power;
    private Node nodeSource;
    private Node nodeDestiny;

    private Vector3 direction;

    //TODO REMOVE CONSTANT
    private const float movementSpeed = 1f; //m/s 
    private const float distanceThreadshold = 0.001f; //m 


    public int GetPower()
    {
        return power;
    }
    public Player GetPlayerOwner()
    {
        return playerOwner;
    }

    public override void Initialize()
    {
        LifeCycle.Initializated();
        playerOwner = null;
        this.power = 1;
        this.nodeSource = null;
        this.nodeDestiny = null;
        direction = Vector3.zero;
        transform.position = Vector3.zero;
    }

    public void StartMoving(Node nodeSource, int power, Node nodeDestiny)
    {
        playerOwner = nodeSource.GetPlayer();
        this.power = power;
        this.nodeSource = nodeSource;
        this.nodeDestiny = nodeDestiny;

        transform.position = this.nodeSource.transform.position;

        direction = nodeDestiny.transform.position - nodeSource.transform.position;
        direction.Normalize();

        if (playerOwner)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", playerOwner.EnemyColor);
        }

        EnablePoolObject();
    }

    public override void UpdatePoolObject()
    {
        if (LifeCycle.GetCurrentStatus() == ObjectLifeCycle.Status.running)
        {

            Vector3 path = nodeDestiny.transform.position - transform.position;

            transform.position += path.normalized * Time.deltaTime * movementSpeed;


            if (path.sqrMagnitude <= distanceThreadshold)
            {
                NodeReached();
            }
        }
    }

    public void NodeReached()
    {
        nodeDestiny.ReceiveHit(this);
        DisablePoolObject();
    }
}
