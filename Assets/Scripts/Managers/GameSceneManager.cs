using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : GenericManager
{
    public BattleDataStorage BattleStorage;
    public SceneController SceneController;
    public DataManager DataManager;
    public BattleController BattleController;
    public GameUIManager UIManager;


    public override void Initialize()
    {
        BattleStorage.Initialize();
        SceneController.Initialize();
        DataManager.Initialize();
        InitializeBattleController();

        UIManager.Initialize(BattleController);
        RegisterEvents();
        initializated = true;
    }

    private void InitializeBattleController()
    {
        int currentLevel = this.DataManager.GetPlayerProgress();

        Debug.Log("Loading level: " + currentLevel);
        BattleScriptableObject battle = this.BattleStorage.GetBattle(currentLevel);
        if(battle)
        {
            BattleController.Initialize(battle);
        }
        else
        {
            Debug.Log("Loading level: " + currentLevel + " - Battle not found");
        }
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
