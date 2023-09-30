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
        [SerializeField] private Image collectedRewardBackgroundImage;
        [SerializeField] private TMP_Text collectedRewardAmount;

        private ItemSO _currentColletedItemSO;
        private int _currentCollectedItemAmount = 0;

        public void SetCollectedRewardData(ItemSO collectedItem, int amount)
        {
            _currentColletedItemSO = collectedItem;
            _currentCollectedItemAmount = amount;
            collectedRewardImage.sprite = _currentColletedItemSO.itemIcon;
            collectedRewardAmount.text = "x"+ _currentCollectedItemAmount.ToString();
            collectedRewardBackgroundImage.color = collectedItem.rewardBackgroundColor;
        }

        public void UpdateCollectedRewardData(int amount)
        {
            _currentCollectedItemAmount += amount;
            collectedRewardAmount.text = "x"+ _currentCollectedItemAmount.ToString();
        }

        public ItemSO GetItemSO()
        {
            return _currentColletedItemSO;
        }

        public int GetItemAmount()
        {
            return _currentCollectedItemAmount;
        }
    }
}
