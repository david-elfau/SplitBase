using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : GenericManager
{
    public GameObject PrefabNodeLabel;
    public GameObject ParentLabels;
    BattleController battleController;

    public RectTransform WinPanel; 
    public RectTransform LostPanel;
    public RectTransform GamePanel;


    public void Initialize(BattleController battleController)
    {
        this.battleController = battleController;
        Initialize();
    }
    public override void Initialize()
    {
        InitNodesLabel();
        RegisterEvents();
        InitialState();
        initializated = true;
    }

    public override void RegisterEvents()
    {
        EventBus.Instance.StartListening(EventName.BattleWin, BattleWin);
        EventBus.Instance.StartListening(EventName.BattleLost, BattleLost);
    }

    public override void UnregisterEvents()
    {
        EventBus.Instance.StopListening(EventName.BattleWin, BattleWin);
        EventBus.Instance.StopListening(EventName.BattleLost, BattleLost);
    }


    public void EventPlayGame()
    {
        Debug.Log("Lanza evento play game");
        EventBus.Instance.TriggerEvent(EventName.BattleStarts,null);
    }
    public void EventExitGame()
    {
        Debug.Log("Lanza evento exit game");
        EventBus.Instance.TriggerEvent(EventName.BattleUnload, null);
    }

    private void InitialState()
    {
        WinPanel.gameObject.SetActive(false);
        LostPanel.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(true);

    }

    private void BattleWin(ParameterBusObject busObject)
    {
        WinPanel.gameObject.SetActive(true);
        LostPanel.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
    }

    private void BattleLost(ParameterBusObject busObject)
    {
        WinPanel.gameObject.SetActive(false);
        LostPanel.gameObject.SetActive(true);
        GamePanel.gameObject.SetActive(false);
    }


    private void InitNodesLabel()
    {
        foreach( Node node in battleController.nodeList)
        {
            NodeLabel label = Instantiate(PrefabNodeLabel, ParentLabels.transform).GetComponent<NodeLabel>();
            label.Initialize(node);
        }
    }


}
