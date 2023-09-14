using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedRewardsPanelDataController : MonoBehaviour
{
    [SerializeField] private CollectedReward collectedRewardPrefab;
    [SerializeField] private Transform collectedRewardPanelParent;

    private List<ItemSO> collectedRewardsSOList = new List<ItemSO>();
    private List<CollectedReward> collectedRewardList = new List<CollectedReward>();

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
}
