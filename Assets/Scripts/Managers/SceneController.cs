
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : GenericManager
{
    private const string mainScene = "MainScene";
    private const string gameScene = "GameScene";

    public override void Initialize()
    {
        RegisterEvents();
        initializated = true;
    }

    public override void RegisterEvents()
    {
        EventBus.Instance.StartListening(EventName.BattleLoad, ChangeToGameScene);
        EventBus.Instance.StartListening(EventName.BattleUnload, ChangeToMainScene);
    }


    public override void UnregisterEvents()
    {
        EventBus.Instance.StopListening(EventName.BattleLoad, ChangeToGameScene);
        EventBus.Instance.StopListening(EventName.BattleUnload, ChangeToMainScene);
    }

    void ChangeToGameScene(object objectParameter)
    {
        Debug.Log("Load game scene");
        StartCoroutine(LoadYourAsyncScene(gameScene));
    }

    public void ChangeToMainScene(object objectParameter)
    {

        Debug.Log("Load main scene");
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
