using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CollectedRewardsPanelDataController : MonoBehaviour
{
    [SerializeField] private CollectedReward collectedRewardPrefab;
    [SerializeField] private Transform collectedRewardPanelParent;

    private List<ItemSO> collectedRewardsSOList = new List<ItemSO>();
    private List<CollectedReward> collectedRewardList = new List<CollectedReward>();

    [Inject]private MoneyManager moneyManager;

    public void AddCollectedReward(ItemSO collectedItemSO, int amount)
    {
        if (collectedRewardsSOList.Contains(collectedItemSO))
        {
            foreach (CollectedReward reward in collectedRewardList)
                if (reward.GetCollectedRewardItemSO().Equals(collectedItemSO))
                {
                    reward.UpdateCollectedItemAmount(amount);
                    break;
                }
        }
        else
        {
            if (collectedItemSO.itemName.Equals("Bomb"))
            {
                //TODO: New features might be added here
            }
            else
            {
                GameObject collectedReward = Instantiate(collectedRewardPrefab.gameObject, collectedRewardPanelParent);
                collectedRewardsSOList.Add(collectedItemSO);
                collectedReward.GetComponent<CollectedReward>().SetCollectedRewardData(collectedItemSO, amount);
                collectedRewardList.Add(collectedReward.GetComponent<CollectedReward>());
            }
        }
    }

    public void GiveCollectedRewards()
    {
        //TODO : Normally all collected rewards will be given to the player but right now only gold and coin gived to player
        foreach(CollectedReward reward in collectedRewardList)
        {
            if(reward.GetCollectedRewardItemSO().itemName.Equals("Gold"))
            {
                moneyManager.UpdateGold(reward.GetCollectedItemAmount());
            }
            else if(reward.GetCollectedRewardItemSO().itemName.Equals("Cash"))
            {
                moneyManager.UpdateCash(reward.GetCollectedItemAmount());
            }
        }

        foreach (Transform currentReward in collectedRewardPanelParent)
            Destroy(currentReward.gameObject);

        collectedRewardsSOList.Clear();
        collectedRewardList.Clear();
    }

    public void ClearCollectedReward()
    {
        foreach (Transform currentReward in collectedRewardPanelParent)
            Destroy(currentReward.gameObject);

        collectedRewardsSOList.Clear();
        collectedRewardList.Clear();
    }
}
