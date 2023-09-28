using System.Collections;
using System.Collections.Generic;
using LWheel.RewardDatabase;
using UnityEngine;
using Zenject;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheelDataController : MonoBehaviour
    {
        [SerializeField] private List<WheelElementController> currentWheelElements = new List<WheelElementController>();

        [Inject] private RewardsDatabase rewardsDatabase;

        private List<Rewards> currentRewards;

        private Rewards currentChosenReward;
        private int currentChosenRewardAmount;
        private int currentChosenRewardIndex;

        private int silverRewardZoneRatio;
        private int goldRewardZoneRatio;

        [Inject] private LuckyWheelImageController wheelImageController;

        public void GetWheelData(int zoneNumber)
        {
            currentRewards = rewardsDatabase.GetRandomElementsForLuckyWheel(zoneNumber);
            wheelImageController.SetLuckyWheelImage(zoneNumber);
            SetBombPositionOnWheel(zoneNumber);
        }

        private void SetBombPositionOnWheel(int zoneNumber)
        {

            if(zoneNumber % silverRewardZoneRatio == 0 || zoneNumber % goldRewardZoneRatio == 0)
            {

            }
            else
            {
                currentRewards[Random.Range(0, currentRewards.Count)] = rewardsDatabase.GetBombReward() ;
            }
        }

        public void SetWheelElementData()
        {
            currentChosenRewardIndex = Random.Range(0, currentRewards.Count);
            for (int i = 0; i < currentWheelElements.Count; i++)
            {
                int randomRewardAmount = Random.Range(currentRewards[i].minRewardAmount, currentRewards[i].maxRewardAmount);
                currentWheelElements[i].SetWheelElementData(currentRewards[i].itemSO, randomRewardAmount);

                if (currentChosenRewardIndex == i)
                    currentChosenRewardAmount = randomRewardAmount;
            }

            currentChosenReward = currentRewards[currentChosenRewardIndex];
        }

        public int GetCurrentRewardIndex()
        {
            return currentChosenRewardIndex;
        }

        public ItemSO GetCurrentRewardItemSO()
        {
            return currentChosenReward.itemSO;
        }

        public int GetCurrentRewardItemAmount()
        {
            return currentChosenRewardAmount;
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            silverRewardZoneRatio = luckyWheelSO.silverLuckyWheelRatio;
            goldRewardZoneRatio = luckyWheelSO.goldLuckyWheelRatio;
        }
    }
}
