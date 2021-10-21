using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Player playerOwner;
    private int power;
    private Node nodeSource;
    private Node nodeDestiny;
    public ObjectLifeCycle LifeCycle;

    private Vector3 position;
    private Vector3 direction;

    //TODO REMOVE CONSTANT
    private const float movementSpeed = 1f; //m/s 

    public void Initialize(Node nodeSource, int power, Node nodeDestiny)
    {
        playerOwner = nodeSource.GetPlayer();
        this.power = power;
        this.nodeSource = nodeSource;
        this.nodeDestiny = nodeDestiny;
        direction = nodeDestiny.transform.position - nodeSource.transform.position;
        direction.Normalize();
        LifeCycle.Initializated();
    }

    internal void Move()
    {
        position = direction * Time.deltaTime * movementSpeed;
    }
}
