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

    private RewardScene rewardScene;

    private void Start()
    {
        rewardScene = GetComponent<RewardScene>();
    }

    public void SetRewardSceneData(ItemSO currentRewardSO, int amount)
    {
        rewardBackground.color = currentRewardSO.rewardBackgroundColor;
        rewardIcon.sprite = currentRewardSO.itemIcon;
        rewardAmount.text = "x"+amount.ToString();

        if(currentRewardSO.IsItemBomb())
        {
            rewardSceneInfoText.text = "You Failed!";
            rewardScene.ButtonBombConfig();
        }
        else
        {
            rewardSceneInfoText.text = "You Rock! Keep Going..";
            rewardScene.ButtonRewardConfig();

        }
    }
}
