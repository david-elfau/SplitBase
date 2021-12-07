using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : GenericManager
{
    public BattleDataStorage BattleProgressionManager;
    public SceneController SceneController;
    public DataManager DataManager;


    public override void Initialize()
    {
        EventBus bus = EventBus.Instance;
        BattleProgressionManager.Initialize();
        SceneController.Initialize();
        DataManager.Initialize();
        RegisterEvents();

        initializated = true;
    }

    private void Awake()
    {
        Initialize();
    }
    

    public override void RegisterEvents()
    {
    }

    public override void UnregisterEvents()
    {
    }

}
