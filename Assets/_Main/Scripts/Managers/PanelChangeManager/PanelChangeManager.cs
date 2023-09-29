using System.Collections;
using System.Collections.Generic;
using LWheel.LuckyWheelNameSpace;
using LWheel.RewardSceneNamespace;
using UnityEngine;

namespace LWheel.PanelChangeNameSpace
{
    public class PanelChangeManager : MonoBehaviour
    {
        [SerializeField] private Transform rewardSceneParent;
        [SerializeField] private Transform luckyWheelSceneParent;

        public void OpenRewardPanel(ItemSO currenRewardSO, int amount)
        {
            luckyWheelSceneParent.gameObject.SetActive(false);
            rewardSceneParent.gameObject.SetActive(true);
            rewardSceneParent.parent.GetComponent<RewardScene>().SetRewardSceneData(currenRewardSO, amount);
            rewardSceneParent.parent.GetComponent<RewardScene>().StartCardAnim();
        }
        public void OpenLuckyWheelPanelAfterReward()
        {
            rewardSceneParent.gameObject.SetActive(false);
            luckyWheelSceneParent.gameObject.SetActive(true);
            luckyWheelSceneParent.parent.GetComponent<LuckyWheel>().ResetLuckyWheelAfterContinueButton();
            rewardSceneParent.parent.GetComponent<RewardScene>().StopCardAnim();

        }
        public void OpenLuckyWheelPanelAfterGiveUp()
        {
            rewardSceneParent.gameObject.SetActive(false);
            luckyWheelSceneParent.gameObject.SetActive(true);
            luckyWheelSceneParent.parent.GetComponent<LuckyWheel>().ResetLuckyWheelAfterGiveUp();
            rewardSceneParent.parent.GetComponent<RewardScene>().StopCardAnim();

        }
    }

}
