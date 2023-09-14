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

    public void GetWheelData(int zoneNumber)
    {
        currentRewards = rewardsDatabase.GetRandomElementsForLuckyWheel(zoneNumber);

        //TODO : Test
        for (int i = 0; i < currentRewards.Count; i++)
            currentRewards[i] = rewardsDatabase.bomb;

        currentRewards[Random.Range(0, currentRewards.Count)] = rewardsDatabase.bomb;
    }

    public void SetWheelElementData()
    {
        currentChosenRewardIndex = Random.Range(0, currentRewards.Count);
        for(int i = 0;i<currentWheelElements.Count;i++)
        {
            int randomRewardAmount = Random.Range(currentRewards[i].minRewardAmount, currentRewards[i].maxRewardAmount);
            currentWheelElements[i].SetWheelElementData(currentRewards[i].itemSO, randomRewardAmount);

            if (currentChosenRewardIndex == i)
                currentChosenRewardAmount = randomRewardAmount;
        }

        currentChosenReward = currentRewards[currentChosenRewardIndex];
    }

    public void ChooseRewardAfterButtonClick()
    {
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
