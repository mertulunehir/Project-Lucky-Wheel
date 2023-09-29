using System;
using System.Collections;
using System.Collections.Generic;
using LWheel.CollectedRewardsNameSpace;
using UnityEngine;
using Zenject;

namespace LWheel.RewardSceneNamespace
{
    public class RewardScene : MonoBehaviour
    {
        [SerializeField] private RewardPanelSO rewardPanelSO;
        [Inject] private RewardSceneDataController rewardSceneDataController;
        [Inject] private RewardSceneButtonController rewardSceneButtonController;
        [Inject] private RewardSceneAnimationController rewardSceneAnimationController;

        [Inject] private CollectedRewardsPanel collectedRewards;

        private void Awake()
        {
            SetDataFromSO();
        }

        private void SetDataFromSO()
        {
            rewardSceneButtonController.SetDataFromSO(rewardPanelSO);
            rewardSceneDataController.SetDataFromSO(rewardPanelSO);
            rewardSceneAnimationController.SetDataFromSO(rewardPanelSO);
        }

        public void SetRewardSceneData(ItemSO currentRewardSO, int amount)
        {
            rewardSceneDataController.SetRewardSceneData(currentRewardSO, amount);
            collectedRewards.AddCollectedReward(currentRewardSO, amount);
            
        }

        public void ButtonRewardConfig()
        {
            rewardSceneButtonController.RewardCollectedButtonConfig();
        }

        public void ButtonBombConfig()
        {
            rewardSceneButtonController.BombCollectedButtonConfig();

        }

        public void GiveCollectedRewards()
        {
            collectedRewards.GiveCollectedRewards();
        }

        public void ClearCollectedRewards()
        {
            collectedRewards.ClearCollectedRewards();
        }

        public void StartCardAnim()
        {
            rewardSceneAnimationController.StartCardAnim();
        }

        public void StopCardAnim()
        {
            rewardSceneAnimationController.StopCardAnim();

        }
    }
}
