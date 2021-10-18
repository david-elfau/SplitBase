using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject NodePrefab;
    public GameObject PlayerPrefab;
    public GameObject PlayerAIPrefab;

    private List<Node> nodeList;
    private List<Unit> unitList;
    private List<PlayerAI> enemyList = new List<PlayerAI>();
    private Player player;
    private ObjectLifeCycle lifeCycle = new ObjectLifeCycle();

    public void Initialize(BattleScriptableObject battleInfo)
    {
        nodeList = new List<Node>();

        foreach (BattleScriptableObject.Node node in battleInfo.NodeList)
        {
            Node gameObject = Instantiate(NodePrefab, this.transform).GetComponent<Node>();

            Vector3 nodePosition = new Vector3(node.Position.x, 0, node.Position.y);

            Player playerNode = AddOrGetPlayer(node.Player);

            gameObject.GetComponent<Node>().Initialize(playerNode, node.InitialPower, nodePosition);

            nodeList.Add(gameObject);
        }


        this.unitList = new List<Unit>(); //TODO CREATE BUNCH OF UNITS

        lifeCycle.Initializated();

        Debug.Log("Nivel cargado");
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
                    player.Initialize(playerSO);
                }
                else
                {
                    PlayerAI ai = Instantiate(PlayerAIPrefab, this.transform).GetComponent<PlayerAI>();
                    ai.Initialize(playerSO);
                    playerOut = ai;
                    enemyList.Add(ai);
                }
            }
        }
        return playerOut;
    }

    public void InitBattle()
    {
        //TODO
        lifeCycle.Play();
    }

    public void EndBattle()
    {
        //TODO
        lifeCycle.End();
    }

    public void NodeConquered()
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
        EndBattle();
        //TODO
        Debug.Log("Victory");
    }
    public void Defeat()
    {
        EndBattle();
        //Defeat
        Debug.Log("Defeat");
    }

    void Update()
    {
        if(lifeCycle.GetCurrentStatus() == ObjectLifeCycle.Status.running)
        {
            foreach(Node node in nodeList)
            {
                node.IncreaseValue();
            }
            foreach (Unit unit in unitList)
            {
                unit.Move();
            }

            foreach(PlayerAI ai in enemyList)
            {
                ai.TakeDecision();
            }
        }
        
    }
}
