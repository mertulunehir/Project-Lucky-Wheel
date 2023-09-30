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

        private List<Rewards> _currentRewards;

        private Rewards _currentChosenReward;
        private int _currentChosenRewardAmount;
        private int _currentChosenRewardIndex;

        private int _silverRewardZoneRatio;
        private int _goldRewardZoneRatio;

        [Inject] private LuckyWheelImageController wheelImageController;

        public void GetWheelData(int zoneNumber)
        {
            _currentRewards = rewardsDatabase.GetRandomElementsForLuckyWheel(zoneNumber);
            wheelImageController.SetLuckyWheelImage(zoneNumber);
            SetBombPositionOnWheel(zoneNumber);
        }

        private void SetBombPositionOnWheel(int zoneNumber)
        {

            if(zoneNumber % _silverRewardZoneRatio == 0 || zoneNumber % _goldRewardZoneRatio == 0)
            {

            }
            else
            {
                _currentRewards[Random.Range(0, _currentRewards.Count)] = rewardsDatabase.GetBombReward() ;
            }
        }

        public void SetWheelElementData()
        {
            _currentChosenRewardIndex = Random.Range(0, _currentRewards.Count);
            for (int i = 0; i < currentWheelElements.Count; i++)
            {
                int randomRewardAmount = Random.Range(_currentRewards[i].minRewardAmount, _currentRewards[i].maxRewardAmount);
                currentWheelElements[i].SetWheelElementData(_currentRewards[i].itemSO, randomRewardAmount);

                if (_currentChosenRewardIndex == i)
                    _currentChosenRewardAmount = randomRewardAmount;
            }

            _currentChosenReward = _currentRewards[_currentChosenRewardIndex];
        }

        public int GetCurrentRewardIndex()
        {
            return _currentChosenRewardIndex;
        }

        public ItemSO GetCurrentRewardItemSO()
        {
            return _currentChosenReward.itemSO;
        }

        public int GetCurrentRewardItemAmount()
        {
            return _currentChosenRewardAmount;
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            _silverRewardZoneRatio = luckyWheelSO.silverLuckyWheelRatio;
            _goldRewardZoneRatio = luckyWheelSO.goldLuckyWheelRatio;
        }
    }
}
