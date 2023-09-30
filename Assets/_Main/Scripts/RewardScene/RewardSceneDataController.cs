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

        private string _failText;
        private string _winText;
        [Inject]private RewardScene rewardScene;


        public void SetRewardSceneData(ItemSO currentRewardSO, int amount)
        {
            rewardBackground.color = currentRewardSO.rewardBackgroundColor;
            rewardIcon.sprite = currentRewardSO.itemIcon;
            rewardAmount.text = "x" + amount.ToString();

            if (currentRewardSO.IsItemBomb())
            {
                rewardSceneInfoText.text = _failText;
                rewardScene.ButtonBombConfig();
            }
            else
            {
                rewardSceneInfoText.text = _winText;
                rewardScene.ButtonRewardConfig();

            }
        }

        public void SetDataFromSO(RewardPanelSO panelSO)
        {
            _failText = panelSO.failText;
            _winText = panelSO.winText;
        }
    }

}
