using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RewardsDatabase : MonoBehaviour
{
    public List<Rewards> firstTierRewards = new List<Rewards>();
    public List<Rewards> secondTierRewards = new List<Rewards>();
    public List<Rewards> thirdTierRewards = new List<Rewards>();

    public Rewards bomb;

    private const int silverRewardZoneNumber = 5;
    private const int goldRewardZoneNumber = 30;

    public List<Rewards> GetRandomElementsForLuckyWheel(int zoneNumber)
    {
        if(zoneNumber<5)
        {
            return GetRandomElements(firstTierRewards);
        }
        else if (zoneNumber == silverRewardZoneNumber)
        {
            return GetRandomElements(firstTierRewards);
        }
        else if(zoneNumber<15)
        {
            return GetRandomElements(secondTierRewards);

        }
        else if(zoneNumber == goldRewardZoneNumber)
        {
            return GetRandomElements(thirdTierRewards);
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
}

[Serializable]
public class Rewards
{
    public ItemSO itemSO;
    public int minRewardAmount;
    public int maxRewardAmount;
}
