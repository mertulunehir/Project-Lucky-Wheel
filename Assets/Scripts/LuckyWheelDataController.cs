using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LuckyWheelDataController : MonoBehaviour
{
    [SerializeField] private List<WheelElementController> currentWheelElements = new List<WheelElementController>();

    [Inject] private RewardsDatabase rewardsDatabase;

    private List<Rewards> currentRewards;

    private Rewards currentChosenReward;
    private int currentChosenRewardAmount;
    private int currentChosenRewardIndex;

    private const int silverRewardZoneNumber = 5;
    private const int goldRewardZoneNumber = 30;

    public void GetWheelData(int zoneNumber)
    {
        currentRewards = rewardsDatabase.GetRandomElementsForLuckyWheel(zoneNumber);
        GetComponent<LuckyWheelImageController>().SetLuckyWheelImage(zoneNumber);
        SetBombPositionOnWheel(zoneNumber);
    }

    private void SetBombPositionOnWheel(int zoneNumber)
    {
        if (zoneNumber < silverRewardZoneNumber)
        {
            currentRewards[Random.Range(0, currentRewards.Count)] = rewardsDatabase.bomb;
        }
        else if (zoneNumber == silverRewardZoneNumber)
        {
        }
        else if (zoneNumber < goldRewardZoneNumber)
        {
            currentRewards[Random.Range(0, currentRewards.Count)] = rewardsDatabase.bomb;
        }
        else if (zoneNumber == goldRewardZoneNumber)
        {
        }
        else
        {
            currentRewards[Random.Range(0, currentRewards.Count)] = rewardsDatabase.bomb;
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
}
