using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : GenericManager
{
    private EventBus EventBus;
    public GameManager GameManager;
    public BattleProgressionManager BattleProgressionManager;
    public SceneController SceneController;
    public BattleController battleController;


    public override void Initialize()
    {
        EventBus bus = EventBus.Instance;
        GameManager.Initialize();
        BattleProgressionManager.Initialize();
        SceneController.Initialize(battleController, BattleProgressionManager);

        //TODO: Init all the managers
        initializated = true;
    }

    private void Awake()
    {
        Initialize();
        DontDestroyOnLoad(this.gameObject);
    }


}
