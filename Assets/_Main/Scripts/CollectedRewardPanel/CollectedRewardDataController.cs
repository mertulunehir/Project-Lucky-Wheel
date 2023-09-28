using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LWheel.CollectedRewardsNameSpace
{

    public class CollectedRewardDataController : MonoBehaviour
    {
        [SerializeField] private Image collectedRewardImage;
        [SerializeField] private TMP_Text collectedRewardAmount;

        private ItemSO currentColletedItemSO;
        private int currentCollectedItemAmount = 0;

        public void SetCollectedRewardData(ItemSO collectedItem, int amount)
        {
            currentColletedItemSO = collectedItem;
            currentCollectedItemAmount = amount;
            collectedRewardImage.sprite = currentColletedItemSO.itemIcon;
            collectedRewardAmount.text = "x"+currentCollectedItemAmount.ToString();
        }

        public void UpdateCollectedRewardData(int amount)
        {
            currentCollectedItemAmount += amount;
            collectedRewardAmount.text = "x"+currentCollectedItemAmount.ToString();
        }

        public ItemSO GetItemSO()
        {
            return currentColletedItemSO;
        }

        public int GetItemAmount()
        {
            return currentCollectedItemAmount;
        }
    }
}
