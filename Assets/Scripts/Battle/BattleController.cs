using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject NodePrefab;
    public GameObject PlayerPrefab;
    public GameObject PlayerAIPrefab;
    public PoolObject UnitPrefab;

    public List<Node> nodeList;
    public ObjectPool unitPool;
    public List<PlayerAI> enemyList = new List<PlayerAI>();
    public Player player;
    public ObjectLifeCycle LifeCycle = new ObjectLifeCycle();



    private void RegisterEvents()
    {
        EventBus.Instance.StartListening(EventName.BattleStarts, InitBattle);
        EventBus.Instance.StartListening(EventName.NodeTapped, NodeTapped);
        EventBus.Instance.StartListening(EventName.NodeConquered, NodeConquered);
    }

    private void UnRegisterEvents()
    {
        EventBus.Instance.StopListening(EventName.BattleStarts, InitBattle);
        EventBus.Instance.StopListening(EventName.NodeTapped, NodeTapped);
        EventBus.Instance.StopListening(EventName.NodeConquered, NodeConquered);
    }
    public void Initialize(BattleScriptableObject battleInfo)
    {
        nodeList = new List<Node>();

        foreach (BattleScriptableObject.Node node in battleInfo.NodeList)
        {
            Node gameObject = Instantiate(NodePrefab, this.transform).GetComponent<Node>();

            Vector3 nodePosition = new Vector3(node.Position.x, 0, node.Position.y);

            Player playerNode = AddOrGetPlayer(node.Player);

            gameObject.GetComponent<Node>().Initialize(playerNode, node.InitialPower, nodePosition,this);

            nodeList.Add(gameObject);
        }

        InitUnits();
        

        RegisterEvents();
        LifeCycle.Initializated();
        Debug.Log("Nivel cargado");
    }


    private void InitUnits()
    {
        unitPool = gameObject.AddComponent(typeof(ObjectPool)) as ObjectPool;
        unitPool.Initialize(UnitPrefab, 500);
    }

    public Player AddOrGetPlayer(PlayerScriptableObject playerSO)
    {
        Player playerOut = null;

        if (playerSO != null)
        {
            foreach (Player p in enemyList)
            {
                if (playerSO.Name == p.Name)
                {
                    playerOut = p;
                    break;
                }
            }

            if (playerOut == null)
            {
                if (playerSO.Name == "Player" && player == null)
                {
                    playerOut = Instantiate(PlayerPrefab, this.transform).GetComponent<Player>();
                    player = playerOut;
                    player.Initialize(playerSO, this);
                }
                else
                {
                    PlayerAI ai = Instantiate(PlayerAIPrefab, this.transform).GetComponent<PlayerAI>();
                    ai.Initialize(playerSO, this);
                    playerOut = ai;
                    enemyList.Add(ai);
                }
            }
        }
        return playerOut;
    }

    public void InitBattle(ParameterBusObject objectParameter)
    {
        //TODO
        foreach (Node node in nodeList)
        {
            node.LifeCycle.Play();
        }

        LifeCycle.Play();

    }

    public void EndBattle(ParameterBusObject objectParameter)
    {
        LifeCycle.End();
        unitPool.DisableFullPool();
    }

    public void NodeConquered(ParameterBusObject objectParameter)
    {
        int playerNodes = 0;
        int enemyNodes = 0;

        foreach(Node node in nodeList)
        {
            if(node.GetPlayer())
            {
                if (node.GetPlayer().Name == "Player")
                {
                    playerNodes++;
                }
                else
                {
                    enemyNodes++;
                }
            }
        }

        if(playerNodes > 0 && enemyNodes < 1)
        {
            Victory();
        }

        if(playerNodes < 1)
        {
            Defeat();
        }
    }

    public void Victory()
    {
        EventBus.Instance.TriggerEvent(EventName.BattleWin, null);
        EndBattle(null);
    }
    public void Defeat()
    {
        EventBus.Instance.TriggerEvent(EventName.BattleLost, null);
        EndBattle(null);
    }

    void Update()
    {
        if(LifeCycle.GetCurrentStatus() == ObjectLifeCycle.Status.running)
        {
            foreach(Node node in nodeList)
            {
                node.IncreaseValue();
            }

            unitPool.UpdatePool();

            foreach(PlayerAI ai in enemyList)
            {
                ai.TakeDecision();
            }
        }        
    }

    public void Attack(Node nodeDestiny, Player player)
    {
        foreach(Node node in nodeList)
        {
            if(node.PlayerOwner == player)
            {
                node.Attack(nodeDestiny);
            }
        }
    }

    public void NodeTapped(ParameterBusObject parameterObject)
    {
        Node nodeDestiny = parameterObject.GetParameterNode();
        if (nodeDestiny)
        {

            Attack(nodeDestiny, player);
        }

    }
}
