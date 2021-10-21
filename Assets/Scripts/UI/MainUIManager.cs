using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : GenericManager
{   
    
    public override void Initialize()
    {
        initializated = true;
    }


    public void EventLoadGame()
    {
        EventBus.Instance.TriggerEvent(EventName.BattleLoad);
    }
}
