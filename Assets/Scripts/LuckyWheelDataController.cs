using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LuckyWheelDataController : MonoBehaviour
{
    [Inject] private RewardsDatabase rewardsDatabase;

    private List<Rewards> currentRewards;

    public void GetWheelData(int zoneNumber)
    {
        currentRewards = rewardsDatabase.GetRandomElementsForLuckyWheel(zoneNumber);

        foreach (Rewards item in currentRewards)
        {
            Debug.Log(item.itemSO.itemName);
        }
    }

    public void SetWheelElementData()
    {

    }
}
