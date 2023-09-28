using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

namespace LWheel.RewardSceneNamespace
{
    public class RewardSceneDataController : MonoBehaviour
    {
        [SerializeField] private Image rewardIcon;
        [SerializeField] private Image rewardBackground;
        [SerializeField] private TMP_Text rewardAmount;
        [SerializeField] private TMP_Text rewardSceneInfoText;

        private string failText;
        private string winText;
        [Inject]private RewardScene rewardScene;


        public void SetRewardSceneData(ItemSO currentRewardSO, int amount)
        {
            rewardBackground.color = currentRewardSO.rewardBackgroundColor;
            rewardIcon.sprite = currentRewardSO.itemIcon;
            rewardAmount.text = "x" + amount.ToString();

            if (currentRewardSO.IsItemBomb())
            {
                rewardSceneInfoText.text = failText;
                rewardScene.ButtonBombConfig();
            }
            else
            {
                rewardSceneInfoText.text = winText;
                rewardScene.ButtonRewardConfig();

            }
        }

        public void SetDataFromSO(RewardPanelSO panelSO)
        {
            failText = panelSO.failText;
            winText = panelSO.winText;
        }
    }

}
