using System;
using System.Collections;
using System.Collections.Generic;
using LWheel.MoneyManagerNameSpace;
using UnityEngine;
using Zenject;

namespace LWheel.CollectedRewardsNameSpace
{

    public class CollectedRewardsPanelDataController : MonoBehaviour
    {
        [SerializeField] private CollectedReward collectedRewardPrefab;
        [SerializeField] private Transform collectedRewardPanelParent;

        private List<ItemSO> _collectedRewardsSOList = new List<ItemSO>();
        private List<CollectedReward> _collectedRewardList = new List<CollectedReward>();

        [Inject] private MoneyManager moneyManager;

        public void AddCollectedReward(ItemSO collectedItemSO, int amount)
        {
            if (_collectedRewardsSOList.Contains(collectedItemSO))
            {
                foreach (CollectedReward reward in _collectedRewardList)
                    if (reward.GetCollectedRewardItemSO().Equals(collectedItemSO))
                    {
                        reward.UpdateCollectedItemAmount(amount);
                        break;
                    }
            }
            else
            {
                if (collectedItemSO.IsItemBomb())
                {
                    //TODO: New features might be added here
                }
                else
                {
                    GameObject collectedReward = Instantiate(collectedRewardPrefab.gameObject, collectedRewardPanelParent);
                    _collectedRewardsSOList.Add(collectedItemSO);
                    collectedReward.GetComponent<CollectedReward>().SetCollectedRewardData(collectedItemSO, amount);
                    _collectedRewardList.Add(collectedReward.GetComponent<CollectedReward>());
                }
            }
        }

        public void GiveCollectedRewards()
        {
            //TODO : Normally all collected rewards will be given to the player but right now only gold and coin gived to player
            foreach (CollectedReward reward in _collectedRewardList)
            {
                if (reward.GetCollectedRewardItemSO().IsItemGold())
                {
                    moneyManager.UpdateGold(reward.GetCollectedItemAmount());
                }
                else if (reward.GetCollectedRewardItemSO().IsItemCash())
                {
                    moneyManager.UpdateCash(reward.GetCollectedItemAmount());
                }
            }

            foreach (Transform currentReward in collectedRewardPanelParent)
                Destroy(currentReward.gameObject);

            _collectedRewardsSOList.Clear();
            _collectedRewardList.Clear();
        }

        public void ClearCollectedReward()
        {
            foreach (Transform currentReward in collectedRewardPanelParent)
                Destroy(currentReward.gameObject);

            _collectedRewardsSOList.Clear();
            _collectedRewardList.Clear();
        }
    }
}

