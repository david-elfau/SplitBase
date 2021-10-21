using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : GenericManager
{
    private const string kMoney = "money";
    private const string kPlayerProgress = "playerProgress";

    private int money = 0;
    private int playerProgress = 0;

    public override void Initialize()
    {
        LoadAll();
        initializated = true;
    }

    void LoadAll()
    {
        money = LoadIntData(kMoney);
        playerProgress = LoadIntData(kPlayerProgress);
    }

    public void SetMoney(int newMoney)
    {
        money = newMoney;
        SaveData(kMoney, money);
    }
    public int GetMoney()
    {
        return money;
    }


    public void SetPlayerProgress(int newProgress)
    {
        playerProgress = newProgress;
        SaveData(kPlayerProgress, playerProgress);
    }
    public int GetPlayerProgress()
    {
        return playerProgress;
    }

    private void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    private int LoadIntData(string key)
    {
        if(PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);

        }
        return 0;
    }
}
