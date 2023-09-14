using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedRewardsPanel : MonoBehaviour
{
    private CollectedRewardsPanelDataController dataController;

    private void Start()
    {
        dataController = GetComponent<CollectedRewardsPanelDataController>();
    }

    public void AddCollectedReward(ItemSO collectedItemSO,int amount)
    {
        dataController.AddCollectedReward(collectedItemSO, amount);
    }

    public void GiveCollectedRewards()
    {
        dataController.GiveCollectedRewards();
    }
}
