using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : GenericManager
{
    public GoldCounter GoldCounterPanel;

    public override void Initialize()
    {
        RegisterEvents();
    }
    public void SetDataManager(DataManager dataManager)
    {
        initializated = true;
        GoldCounterPanel.Initialize(dataManager);
    }


    public void EventLoadGame()
    {
        EventBus.Instance.TriggerEvent(EventName.BattleLoad, null);
    }

    public override void RegisterEvents()
    {
    }

    public override void UnregisterEvents()
    {
    }
}
