using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWheel.CollectedRewardsNameSpace
{
    public class CollectedReward : MonoBehaviour
    {
        [SerializeField] private CollectedRewardDataController dataController;


        public void SetCollectedRewardData(ItemSO collectedItemSO, int amount)
        {
            dataController.SetCollectedRewardData(collectedItemSO, amount);
        }

        public void UpdateCollectedItemAmount(int amount)
        {
            dataController.UpdateCollectedRewardData(amount);
        }
        public int GetCollectedItemAmount()
        {
            return dataController.GetItemAmount();
        }

        public ItemSO GetCollectedRewardItemSO()
        {
            return dataController.GetItemSO();
        }

    }

}
