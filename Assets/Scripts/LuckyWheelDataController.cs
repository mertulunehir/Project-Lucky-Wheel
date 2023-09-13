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

    public void GetWheelData(int zoneNumber)
    {
        currentRewards = rewardsDatabase.GetRandomElementsForLuckyWheel(zoneNumber);
    }

    public void SetWheelElementData()
    {
        for(int i = 0;i<currentWheelElements.Count;i++)
        {
            int randomRewardAmount = Random.Range(currentRewards[i].minRewardAmount, currentRewards[i].maxRewardAmount);
            currentWheelElements[i].SetWheelElementData(currentRewards[i].itemSO, randomRewardAmount);
        }
    }

    public void ChooseRewardAfterButtonClick()
    {
        currentChosenReward = currentRewards[Random.Range(0, currentRewards.Count)];
    }

    public int GetCurrentRewardIndex()
    {
        return currentRewards.IndexOf(currentChosenReward);
    }
}
