using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : GenericManager
{
    public GameObject PrefabNodeLabel;
    public GameObject ParentLabels;
    BattleController battleController;

    public void Initialize(BattleController battleController)
    {
        this.battleController = battleController;
        InitNodesLabel();
        initializated = true;
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

    private void InitNodesLabel()
    {
        foreach( Node node in battleController.nodeList)
        {
            NodeLabel label = Instantiate(PrefabNodeLabel, ParentLabels.transform).GetComponent<NodeLabel>();
            label.Initialize(node);
        }

    }

}
