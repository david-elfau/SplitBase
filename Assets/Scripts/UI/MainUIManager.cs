using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUIManager : GenericManager
{
    public GoldCounter GoldCounterPanel;
    public TextMeshProUGUI TextLevel;

    public override void Initialize()
    {
        RegisterEvents();
    }

    public override void RegisterEvents()
    {
    }

    public override void UnregisterEvents()
    {
    }

    public void SetDataManager(DataManager dataManager)
    {
        GoldCounterPanel.Initialize(dataManager);
        InitLevelLabel(dataManager);

        initializated = true;
    }


    public void EventLoadGame()
    {
        EventBus.Instance.TriggerEvent(EventName.BattleLoad, null);
    }


    private void InitLevelLabel(DataManager dataManager)
    {
        TextLevel.text = "Level " + (dataManager.GetPlayerProgress()+1);
    }
}
