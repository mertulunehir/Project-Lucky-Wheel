using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
    public Transform rewardSceneParent, luckyWheelSceneParent;

    public void OpenRewardScene(ItemSO currenRewardSO, int amount)
    {
        luckyWheelSceneParent.gameObject.SetActive(false);
        rewardSceneParent.gameObject.SetActive(true);
        rewardSceneParent.parent.GetComponent<RewardScene>().SetRewardSceneData(currenRewardSO, amount);

    }
    public void OpenLuckyWheelSceneContinue()
    {
        rewardSceneParent.gameObject.SetActive(false);
        luckyWheelSceneParent.gameObject.SetActive(true);
        luckyWheelSceneParent.parent.GetComponent<LuckyWheel>().ResetLuckyWheelAfterContinueButton();
    }
    public void OpenLuckyWheelSceneGiveUp()
    {

    }
}
