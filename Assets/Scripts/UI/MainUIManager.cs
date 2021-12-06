using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : GenericManager
{   
    
    public override void Initialize()
    {
        RegisterEvents();
        initializated = true;
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
