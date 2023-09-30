using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace LWheel.RewardDatabase
{
    public class RewardsDatabase : MonoBehaviour
    {
        [SerializeField] private RewardsDatabaseSO databaseSO;

        private List<Rewards> _firstTierRewards = new List<Rewards>();
        private List<Rewards> _secondTierRewards = new List<Rewards>();
        private List<Rewards> _thirdTierRewards = new List<Rewards>();

        private int _secondTierStartZone;
        private int _thirdTierStartZone;

        private Rewards bomb;

        private void Awake()
        {
            SetDataFromSO();
        }

        private void SetDataFromSO()
        {
            _firstTierRewards = databaseSO.firstTierRewards;
            _secondTierRewards = databaseSO.secondTierRewards;
            _thirdTierRewards = databaseSO.thirdTierRewards;

            _secondTierStartZone = databaseSO.secondTierStartZone;
            _thirdTierStartZone = databaseSO.thirdTierStartZone;

            bomb = databaseSO.bomb;
        }

        public List<Rewards> GetRandomElementsForLuckyWheel(int zoneNumber)
        {
            if (zoneNumber < _secondTierStartZone)
            {
                return GetRandomElements(_firstTierRewards);
            }
            else if (zoneNumber < _thirdTierStartZone)
            {
                return GetRandomElements(_secondTierRewards);
            }
            else
            {
                return GetRandomElements(_thirdTierRewards);
            }
        }

        private List<Rewards> GetRandomElements(List<Rewards> currentRewards)
        {
            Random random = new Random();

            List<Rewards> randomSelection = new List<Rewards>();

            for (int i = 0; i < 8; i++)
            {
                int randomIndex = random.Next(currentRewards.Count);
                Rewards selectedElement = currentRewards[randomIndex];
                randomSelection.Add(selectedElement);
            }

            return randomSelection;

        }

        public Rewards GetBombReward()
        {
            return bomb;
        }
    }

    [Serializable]
    public class Rewards
    {
        public ItemSO itemSO;
        public int minRewardAmount;
        public int maxRewardAmount;
    }
}
