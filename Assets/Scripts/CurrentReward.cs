using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentReward : MonoBehaviour
{
    
    private CurrentRewardDataController dataController;

    void Start()
    {
        dataController = GetComponent<CurrentRewardDataController>();
    }



    public void SetCurrentItemRewardInformation(Sprite currentIcon)
    {
        dataController.SetCurrentItemRewardInformation(currentIcon);
    }

    public void SetCurrentMoneyRewardInformation(Sprite currentIcon, int rewardAmount)
    {
        dataController.SetCurrentMoneyRewardInformation(currentIcon,rewardAmount);
    }

    public void UpdateCurrentItemRewardAmount()
    {
        dataController.UpdateCurrentItemRewardAmount();
    }

    public void UpdateCurrentMoneyRewardAmount(int rewardAmount)
    {
        dataController.UpdateCurrentMoneyRewardAmount(rewardAmount);
    }

}
