
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : GenericManager
{
    private const string mainScene = "MainScene";
    private const string gameScene = "GameScene";
    BattleController battleController = null;
    BattleProgressionManager battleProgressionManager = null;
    EventBus bus;


    public void Initialize(BattleController battleController, BattleProgressionManager battleProgressionManager)
    {
        this.battleController = battleController;
        this.battleProgressionManager = battleProgressionManager;
        EventBus.Instance.StartListening(EventName.BattleStarts, ChangeToGameScene);
        EventBus.Instance.StartListening(EventName.BattleEnds, ChangeToMainScene);

        initializated = true;
    }
    void ChangeToGameScene()
    {
        StartCoroutine(LoadYourAsyncScene(gameScene));
        battleController.Initialize(battleProgressionManager.GetBattleScriptableObject());
    }
    public void ChangeToMainScene()
    {
        StartCoroutine(LoadYourAsyncScene(mainScene));
    }


    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
