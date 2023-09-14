using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RewardScene : MonoBehaviour
{
    private RewardSceneDataController rewardSceneDataController;
    private RewardSceneButtonController rewardSceneButtonController;

    [Inject]private CollectedRewardsPanel collectedRewards;


    void Start()
    {
        rewardSceneDataController = GetComponent<RewardSceneDataController>();
        rewardSceneButtonController = GetComponent<RewardSceneButtonController>();
    }

    public void SetRewardSceneData(ItemSO currentRewardSO,int amount)
    {
        rewardSceneDataController.SetRewardSceneData(currentRewardSO,amount);

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
}
