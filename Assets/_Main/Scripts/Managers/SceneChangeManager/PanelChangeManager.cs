using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChangeManager : MonoBehaviour
{
    public Transform rewardSceneParent, luckyWheelSceneParent;

    public void OpenRewardScene(ItemSO currenRewardSO, int amount)
    {
        luckyWheelSceneParent.gameObject.SetActive(false);
        rewardSceneParent.gameObject.SetActive(true);
        rewardSceneParent.parent.GetComponent<RewardScene>().SetRewardSceneData(currenRewardSO, amount);
    }
    public void OpenLuckyWheelSceneAfterReward()
    {
        rewardSceneParent.gameObject.SetActive(false);
        luckyWheelSceneParent.gameObject.SetActive(true);
        luckyWheelSceneParent.parent.GetComponent<LuckyWheel>().ResetLuckyWheelAfterContinueButton();
    }
    public void OpenLuckyWheelSceneAfterGiveUp()
    {
        rewardSceneParent.gameObject.SetActive(false);
        luckyWheelSceneParent.gameObject.SetActive(true);
        luckyWheelSceneParent.parent.GetComponent<LuckyWheel>().ResetLuckyWheelAfterGiveUp();
    }
}
