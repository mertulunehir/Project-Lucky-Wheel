using System.Collections;
using System.Collections.Generic;
using LWheel.LuckyWheelNameSpace;
using LWheel.RewardSceneNamespace;
using UnityEngine;

namespace LWheel.PanelChangeNameSpace
{
    public class PanelChangeManager : MonoBehaviour
    {
        [SerializeField] private Transform rewardSceneParent, luckyWheelSceneParent;

        public void OpenRewardPanel(ItemSO currenRewardSO, int amount)
        {
            luckyWheelSceneParent.gameObject.SetActive(false);
            rewardSceneParent.gameObject.SetActive(true);
            rewardSceneParent.parent.GetComponent<RewardScene>().SetRewardSceneData(currenRewardSO, amount);
        }
        public void OpenLuckyWheelPanelAfterReward()
        {
            rewardSceneParent.gameObject.SetActive(false);
            luckyWheelSceneParent.gameObject.SetActive(true);
            luckyWheelSceneParent.parent.GetComponent<LuckyWheel>().ResetLuckyWheelAfterContinueButton();
        }
        public void OpenLuckyWheelPanelAfterGiveUp()
        {
            rewardSceneParent.gameObject.SetActive(false);
            luckyWheelSceneParent.gameObject.SetActive(true);
            luckyWheelSceneParent.parent.GetComponent<LuckyWheel>().ResetLuckyWheelAfterGiveUp();
        }
    }

}
