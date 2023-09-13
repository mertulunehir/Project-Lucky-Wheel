using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardSceneDataController : MonoBehaviour
{
    [SerializeField] private Image rewardIcon;
    [SerializeField] private Image rewardBackground;
    [SerializeField] private TMP_Text rewardAmount;
    [SerializeField] private TMP_Text rewardSceneInfoText;

    public void SetRewardSceneData(ItemSO currentRewardSO, int amount)
    {
        rewardBackground.color = currentRewardSO.rewardBackgroundColor;
        rewardIcon.sprite = currentRewardSO.itemIcon;
        rewardAmount.text = "x"+amount.ToString();

        if(currentRewardSO.itemName.Equals("Bomb"))
        {
            rewardSceneInfoText.text = "You Failed!";
        }
        else
        {
            rewardSceneInfoText.text = "You Rock! Keep Going..";
        }
    }
}
