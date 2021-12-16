using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardPanel : MonoBehaviour
{
    public TextMeshProUGUI TextGoldAmount;

    public void Initialize(BattleScriptableObject battleData)
    {
        SetGoldValue(battleData.GoldReward);
    }

    public void SetGoldValue(int goldAmount)
    {
        TextGoldAmount.text = "+" + goldAmount + "<sprite=0>";

    }
}
