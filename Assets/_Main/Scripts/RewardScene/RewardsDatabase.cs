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

        private List<Rewards> firstTierRewards = new List<Rewards>();
        private List<Rewards> secondTierRewards = new List<Rewards>();
        private List<Rewards> thirdTierRewards = new List<Rewards>();

        private int secondTierStartZone;
        private int thirdTierStartZone;

        private Rewards bomb;

        private void Awake()
        {
            SetDataFromSO();
        }

        private void SetDataFromSO()
        {
            firstTierRewards = databaseSO.firstTierRewards;
            secondTierRewards = databaseSO.secondTierRewards;
            thirdTierRewards = databaseSO.thirdTierRewards;

            secondTierStartZone = databaseSO.secondTierStartZone;
            thirdTierStartZone = databaseSO.thirdTierStartZone;

            bomb = databaseSO.bomb;
        }

        public List<Rewards> GetRandomElementsForLuckyWheel(int zoneNumber)
        {
            if (zoneNumber < secondTierStartZone)
            {
                return GetRandomElements(firstTierRewards);
            }
            else if (zoneNumber < thirdTierStartZone)
            {
                return GetRandomElements(secondTierRewards);
            }
            else
            {
                return GetRandomElements(thirdTierRewards);
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
