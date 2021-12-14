using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    public TextMeshProUGUI GoldAmount;
    DataManager dataManager;

    public void Initialize(DataManager dataManager)
    {
        this.dataManager = dataManager;
        UpdateGoldValue();
    }

    public void UpdateGoldValue()
    {
        UpdateGoldValue(dataManager.GetMoney());
    }

    void UpdateGoldValue(float newValue)
    {
        GoldAmount.text = string.Format("{0:#,0'}", newValue);
    }
}
